# jaytwo.CommonLib

A library full of code helpers that I find useful.

## Highlights

Some examples of what I mean by 'helpers'... and what I consider 'useful'...

### String Parsing

Parse and TryParse extension methods for common primitives: `Boolean`, `Byte`, `DateTime`, `Decimal`, `Double`, `Int16`, `Int32`, `Int64`, `SByte`, `Single`, `UInt16`, `UInt32`, `UInt64`.  

```cs
using jaytwo.Common.Extensions
...
// parse string to int, throws exception on failure
int intValue = stringValue.ParseInt32();

// parse string to int, swallow exception on failure and returns null
int? intValue = stringValue.TryParseInt32();

// parse string to int, swallow exception on failure, use -1 as default value
int intValue = stringValue.TryParseInt32() ?? -1;

// parses true/false, t/f, yes/no, y/n, 1/0
bool boolValue = stringValue.ParseBoolean();
```

Plus several more Parse/TryParse methods like: `ParseXml()`, `ParseXDocument()`, `ParseJsonAsDynamic()`.

```cs
using jaytwo.Common.Extensions
...
// parse json dictionary to dynamic, throws exception on failure
var response = stringValue.ParseJsonAsDynamic();
Console.WriteLine(response.message);

// and if you forget if they capitalize the 'm' on message
var response = stringValue.ParseJsonAsDynamic(StringComparer.OrdinalIgnoreCase);
Console.WriteLine(response.MeSsAgE);

// parse json as XML and grab what you need with XPath
var response = uri.PutJson(payload).ParseJsonAsXmlDocument();
Console.WriteLine(response.GetXPathValue("/error/message"));
```

### Comparing DateTime Values

Boolean expressions often get hard to read when doing anything complex, so I use these methods to make the code more expressive.

```cs
using jaytwo.Common.Extensions
...
var yesterday = DateTime.Today.AddDays(-1);
var now = DateTime.Now;
var lunchTime = DateTime.Now.AddMinutes(10);
var tomorrow = DateTime.Today.AddDays(1);

now.IsAfter(yesterday); // returns true
now.IsAfter(lunchTime); // returns false
now.IsSameDayAs(lunchTime); // reutrns true
now.IsSameDayOrBefore(lunchTime); // reutrns true
tomorrow.IsSameDayOrAfter(yesterday); // returns true
```

### HTTP Operations

I am certainly not trying to create *yet another* .NET REST library.  However, most of the time I just need to get the string or binary response from a web URL... so I made that easy to do.

```cs
using jaytwo.Common.Extensions
...
// simple HTTP GET
var uri = new Uri("http://www.google.com");
var html = uri.DownloadString();

// URI manipulation, method chaining
var html = new Uri("http://www.google.com")
  .WithQueryStringParameter("q", "chuck norris");
  .DownloadString();

// HTTP PUT with JSON values, and load the response into a dynamic object
var request = new { firstName = "John", lastName = "Doe" };
var response = uri.PutJson(request).ParseJsonAsDynamic();
Console.WriteLine(response.message);
```

