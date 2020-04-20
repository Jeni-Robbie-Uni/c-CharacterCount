# Character Counter

Character counter is a command line program that reads text files and outputs the top 10 characters, by frequency.

## Parameters
Parameter 1 - File Name (required) (must be in the same directory as the executable)

Parameter 2 - caseoff (optional) - the presence of this flag indicates that the application should disable case-sensitive counting

## Usage

```bash
CharacterCount.exe Test.txt #will count number of characters in file, and default to case sensitive count

CharacterCount.exe Test.txt caseoff #will count number of characters in file, with case sensitivity disabled
```