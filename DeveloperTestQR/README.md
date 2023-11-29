# Developer test
## Task 1 – Design
- Create three Vehicle classes, e.g. Car, Bicycle etc. Give each class some relevant properties.
- Set all properties to fixed values in their constructor, e.g. MaxSpeed of Car is set to 150.
It is not relevant to consider the fact that different cars have different maximum speeds, nor is it relevant whether the properties are assignable outside of the constructor.
## Task 2 – Reflection
- Create an InstanceService class with the method IEnumerable<T> GetInstances() which returns an instance of every class of type T.
- Create a fourth Vehicle class. This new class should automatically be returned from InstanceService.GetInstances() without necessitating changes to the implementation of InstanceService.
## Task 3 – Functionality
- Create a console application which writes every Vehicle type name to the console, sorted alphabetically.
- Create a method which can search for types by specifying part of the name.
- Create a method which can write all instances returned from InstanceService.GetInstances() to disk.
## Task 4 – Problem-solving
- Create a method string ReverseString(string s) which returns a reversed version of the input string.
  - Do not use String.Reverse()
- Create a method with the signature bool IsPalindrome(string s) which checks whether the input string is a palindrome (see definition below)
- Create a method IEnumerable<int> MissingElements (int[] arr) which takes as an argument an array of integers. It may be assumed that the input sequence is sorted in ascending order.
  Two conditions are placed on arr:
  - The sequence must increase by 1 for each element of arr, starting with the smallest element present.
  - The number sequence must be complete, starting with the smallest element of arr, and ending with the largest.
  - If numbers are missing from arr in order to fulfill these conditions, they should be returned by the method.
  - If no elements are missing, the call should result in an empty collection.
  - Example inputs and results
    - arr = [4,6,9] should result in [5,7,8]
    - arr = [2,3,4] should result in [ ]
    - arr = [1,3,4] should result in [2]

