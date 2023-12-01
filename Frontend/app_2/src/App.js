import React, { useEffect, useState } from 'react';
import './App.css';

const dataSource = "http://167.71.69.158";

async function fetchData() {
    const response = await fetch(dataSource + "/static/test.json")
        .then(response => response.json());

    response.terms_of_use.paragraphs.sort((a, b) => a.index - b.index);
    return response;
}

function TermsOfUse({ paragraphs, onAccept }) {
    return (
        <div className='terms-container'>
            <h2>Terms of Use</h2>
            {paragraphs.map((paragraph, index) => (
                <div key={index} className='paragraph'>
                    <span className='subtitle'>{paragraph.title}</span>
                    <p className='paragraph-text'>{paragraph.hasOwnProperty('content') ? paragraph.content : paragraph.text}</p>
                </div>
            ))}
            <button className='button' onClick={onAccept}>Accept</button>
        </div>
    );
}

function GalleryCell({ imageUrl }) {
    const [canvas, setCanvas] = useState(null);

    useEffect(() => {
        const img = new Image();
        img.src = dataSource + imageUrl;
        img.crossOrigin = "anonymous";
        
        img.onload = () => {
            const canvas = document.createElement('canvas');
            const ctx = canvas.getContext('2d');
            canvas.width = img.width;
            canvas.height = img.height;
            ctx.drawImage(img, 0, 0);
            setCanvas(ctx.canvas);
        };
    }, [imageUrl]);

    const saveImage = () => {
        const link = document.createElement('a');
        link.download = imageUrl.split("/").slice(-1);
        link.href = canvas.toDataURL('image/png')
        link.click();
    };

    return (
        <div className='gallery-cell'>
            {canvas && <img src={canvas.toDataURL('image/png')} alt="" />}
            <button className='button' onClick={saveImage}>Save</button>
        </div>
    );
}

function Gallery({ images }) {
    return (
        <div id='gallery' className='gallery'>
            {images.map((image, index) => (
                <GalleryCell key={index} imageUrl={image.image_url} />
            ))}
        </div>
    );
}

function App() {
    const [data, setData] = useState(null);
    const [termsAccepted, setTermsAccepted] = useState(false);

    useEffect(() => {
        fetchData().then((data) => setData(data));
    }, []);

    const acceptTermsOfUse = () => {
        setTermsAccepted(true)
    };

    if (!data) {
        return null;
    }

    return (
        <div id='container'>
            <h1>Image Gallery</h1>
            {!termsAccepted && <TermsOfUse paragraphs={data.terms_of_use.paragraphs} onAccept={acceptTermsOfUse} />}
            {termsAccepted && <Gallery images={data.images} />}
        </div>
    );
}

export default App;