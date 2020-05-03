# regex-composer
Compose regular expressions using code

## Usage
```csharp
// +1 555-555-5555
// country code and separators optional

var digit = Pattern.Digit;
var dash = Pattern.Dash;
var space = Pattern.Space;
var separator = new Optional(dash | space);

var optionalPlus = Pattern.Plus.Optional();
var someDigits = new OneOrMore(digit);

var countryCode = new Optional(optionalPlus + someDigits);
var phone = countryCode + separator + digit * 3 + separator + digit * 3 + separator + digit * 4;

var regex = phone.ToRegex();

Assert.IsTrue(regex.IsMatch("+1 555-555-5555"));
```
