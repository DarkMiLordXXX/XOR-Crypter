using System.Text;

// Input
Console.Write("Input your text: ");
string inputText = Console.ReadLine();
Console.Write("Input your safe key: ");
string key = Console.ReadLine();

ASCIIEncoding asciiText = new ASCIIEncoding();
ASCIIEncoding asciiKey = new ASCIIEncoding();
Byte[] encodedKey = asciiKey.GetBytes(key); // Get array bytes from string key
Byte[] encodedBytes = asciiText.GetBytes(inputText);   // Get array bytes from string
Byte[] encryptedBytes = new Byte[encodedBytes.Length];  // This array for encrypted byte
Byte[] decryptedBytes = new Byte[encodedBytes.Length];  // This array for decrypted byte
int sizeArray = 0;  // This variable saves array length that would for add/edit elements encrypted or decrypted bytes
int sizeKey = 0;    // This variable saves key length
int charKey = 0;    // This variable saves byte symbol from key

// ENCRYPED
foreach (Byte charByte in encodedBytes) {
    for( ; sizeArray != encodedBytes.Length; sizeArray++)
    {
        for( ; sizeKey != encodedKey.Length; sizeKey++)  // !!! This needs to be redesigned !!! (Going through bytes in key)
        {
            if(sizeKey > encodedKey.Length - 1)     // The condition is that the loop will not stop if the key length is less than the string length.
            {
                sizeKey = 0;
            }
            charKey = encodedKey[sizeKey]; // Saves byte symbol from key
            sizeKey++;
            break;
        }
        //Console.WriteLine($"Convert: {Convert.ToByte(b ^ 4)}");     // *** debug info ***
        //Console.WriteLine($"Index bt: {encryptedBytes[sizeArray]}");    // *** debug info ***
        encryptedBytes[sizeArray] = Convert.ToByte(charByte ^ charKey);      // Encryptes bytes from 'encodedBytes' by using key.
        //Console.WriteLine($"Index bt (after): {encryptedBytes[sizeArray]}");
        sizeArray++;
        break;
    }
}
sizeArray = 0;  // Zeroing variable for next step
sizeKey = 0;    // Zeroing variable for next step


// DECRYPED
foreach (Byte charByte in encryptedBytes) {
    for( ; sizeArray != encodedBytes.Length; sizeArray++)
    {
        for( ; sizeKey != encodedKey.Length; sizeKey++)     // !!! This needs to be redesigned !!! (Going through bytes in key)
        { 
            if(sizeKey > encodedKey.Length - 1)     // The condition is that the loop will not stop if the key length is less than the string length.
            {
                sizeKey = 0;
            }
            charKey = encodedKey[sizeKey];      // Saves byte symbol from key
            sizeKey++;
            break;
        }
        decryptedBytes[sizeArray] = Convert.ToByte(charByte ^ charKey);    // Decryptes bytes from 'encryptedBytes' in 'decryptedBytes' by using key.
        sizeArray++;
        break;
    }
}
sizeArray = 0; // Zeroing variable finally
sizeKey = 0; // Zeroing variable finally

// Output result
String encryptedString = asciiText.GetString(encryptedBytes); // Convert to string from bytes 'encryptedBytes'
Console.WriteLine($"Encrypted string: ");
Console.WriteLine(encryptedString);

String decodedString = asciiText.GetString(decryptedBytes); // Convert to string from bytes 'decryptBytes'
Console.WriteLine($"Decrypted string: {decodedString}");



