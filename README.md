# PigLatin Translator 

This "questionable" tool was created as an exercise in C# and .NET core.
It is based on challange by Andrew Rosenwinkel published on edabit.com<br>
Link: https://edabit.com/challenge/uhsik73PY7Y2XftzG

### Web-app
You can test the tool by using a web app.<br>
Link: https://piglet.mkajzer.hostingasp.pl/

### Web-api
There is also public API available:

GET: http://pigletapi.mkajzer.hostingasp.pl/api/translate<br>
To use this method you need to provide source string as query parameter "?source=xxx"<br> 
Example: http://pigletapi.mkajzer.hostingasp.pl/api/translate?source=here%20goes%20what%20you%20want%20to%20translate<br>
You can test that simply by accessing it with your browser

POST: http://pigletapi.mkajzer.hostingasp.pl/api/translate<br>
This method requires JSON with string array:<br>
<code>
  {
	"sourceStrings":
	[
		"This is my test string number one",
		"Let's test some more",
		"Even more testing!",
	]
}
  </code><br>
As a response you'll get JSON with an array that contains translated strings.<br>
Postman or other tool that allows sending POST requests is needed. 
  

### How it works:
<b>Consonant starting words:</b> move consonants from the begging of the word to the end and add "ay".<br>
<b>Vowel starting words:</b> add "yay" at the end of the word.

apple > appleyay<br>
edit > edityay<br>
elaborate > elaborateyay<br>
car > arcay<br>
fallout > alloutfay<br>
translator > anslatortray<br>
