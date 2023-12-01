var dataSource = "http://167.71.69.158"

async function fetchData() {
    const response = await fetch(dataSource + "/static/test.json")
        .then(response => response.json());

    response.terms_of_use.paragraphs.sort((a, b) => a.index - b.index);
    return response;
}

function getParagraphElement(paragraph){
    let paragraphDiv = document.createElement('div')
    paragraphDiv.className = 'paragraph'

    let subtitle = document.createElement('span');
    subtitle.className = 'subtitle';
    subtitle.textContent = paragraph.title;
    paragraphDiv.appendChild(subtitle);

    let content = document.createElement('p');
    content.textContent = paragraph.hasOwnProperty('content') ? paragraph.content : paragraph.text;
    content.className = 'paragraph-text'
    paragraphDiv.appendChild(content)

    return paragraphDiv
}

async function acceptTermsOfUse(paragraphs) {
    return new Promise((resolve) => {
        console.log(paragraphs)
        let termsDiv = document.createElement('div');
        termsDiv.className = 'terms-container'

        let termsHeader = document.createElement('h2')
        termsHeader.textContent = "Terms of Use"
        termsDiv.appendChild(termsHeader)
        
        paragraphs.forEach(paragraph => {
            let paragraphDiv = getParagraphElement(paragraph)
            termsDiv.appendChild(paragraphDiv)
        });

        const button = document.createElement('button');
        button.className = 'button'
        button.innerText = 'Accept';
        button.addEventListener('click', () => {
            termsDiv.style.display = 'none';
            resolve();
        });

        termsDiv.appendChild(button)
        
        document.body.appendChild(termsDiv);
    });
}

async function renderImageToCanvas(imageUrl) {
    const img = new Image();
    img.src = dataSource + imageUrl;
    img.crossOrigin = "anonymous";
    
    const canvas = document.createElement('canvas');
    const ctx = canvas.getContext('2d');

    img.onload = () => {
        canvas.width = img.width;
            canvas.height = img.height;
            ctx.drawImage(img, 0, 0);
    };

    return ctx.canvas;
}

function saveImage(canvas, filename) {
    const link = document.createElement('a');
    link.download = filename;
    link.href = canvas.toDataURL('image/png')
    link.click();
}

function drawGallery(){
    let container = document.getElementById('container');
    let galleryHeader = document.createElement('h1');
    galleryHeader.textContent = "Image Gallery"
    container.appendChild(galleryHeader)

    let gallery = document.createElement('div');
    gallery.id = 'gallery'
    gallery.className = 'gallery'

    container.appendChild(gallery)
}

async function drawGalleryCell(image_url){
    let gallery = document.getElementById('gallery');

    let galleryCell = document.createElement('div');
    galleryCell.className = 'gallery-cell';

    const canvas = await renderImageToCanvas(image_url);
    galleryCell.appendChild(canvas);

    const button = document.createElement('button');
    button.innerText = 'Save';
    button.className = 'button'
    let filename = image_url.split("/").slice(-1);
    button.addEventListener('click', () => saveImage(canvas, filename));

    galleryCell.appendChild(button);
    gallery.appendChild(galleryCell);
}

async function main() {
    const data = await fetchData();
    drawGallery()

    await acceptTermsOfUse(data.terms_of_use.paragraphs);
    for (const image of data.images) {
        console.log(image.image_url);
        await drawGalleryCell(image.image_url);
    }
}

main();