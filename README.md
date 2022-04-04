This program will generate two random strings whose hash is the same. 
It uses the C#'s outdated [MD5 hashing algorithm](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netcore-3.1) to generate the hash. 

The program takes in a hexadecimal string representing a salt byte that will be appeneded to the random strings. 

In order to generate the strings, the program implements a simple version of the popular [Birthday Attack](https://en.wikipedia.org/wiki/Birthday_attack) whose depends on the higher likelihood of collisions found between random attack attempts and a fixed degree of permutations.



### Example
Expected arguments:
* Salt Byte
* Length used in the generation of the colliding random strings
* Length of the hash (in bytes)

Output:
* Byte array of the hash
* Set of colliding strings
```
~ P2 dotnet run C5 10 5 
Hash: '5F 4B AA C7 79'
Collision strings: 'XcrUQJaGji', '1pXlux2LZ0'

~ P2 dotnet run C5 10 4
Hash: 'EB CB 45 26'
Collision strings: 'GHojObSlPS', 'b2q5VtmdMZ'
```
