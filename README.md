# ![PersianDatePicker](https://raw.githubusercontent.com/AliRoostae/Blazor_PersianDatePickerZO/master/img/PersianDatePicker.jpg)


## Prerequisites
- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0) for v6.x.x 

### Quick Installation Guide
Install Package
```
Install-Package Blazor_PersianDatePickerZO
```

Add the following to `index.html` (client-side) or `_Host.cshtml` (server-side) in the `head`
```
<link href="_content/Blazor_PersianDatePickerZO/AppDtaePickerZeroOne.css" rel="stylesheet" />
```

Add the following to `_Imports.razor`
```
@using Blazor_PersianDatePickerZO.Component
@using Blazor_PersianDatePickerZO.Hellper
```

## Usage
### calendar use 
```
< ZeroOneDatePicker PupupDatePickerZO="true OR false" @bind-SelectDate="@value">

@code {
  public DateTime value { get; set; } 
}
```

### calendar range use 
```
<ZeroOneDatePickerRange SelectDateFirst="@dateFirst" SelectDateLast="@dateLast"  />

@code {
  public DateTime dateFirst { get; set; } 
  public DateTime dateLast { get; set; } 
}
```

### color themplate
```
< ZeroOneDatePicker ThemePickerZO="ThemeDatePickerZO.darkblue">
```
```
enum ThemeDatePickerZO
{
 	lightgreen,
   lightred,
   lightblue,
   lightpurple,
   lightorange,
   lightgray,
   darkgreen,
   darkred,
   darkblue,
   darkpurple,
   darkorange,
   darkgray    
}
```


### use single part  
#### Time Only
```
 <TimeZO   @bind-SelectDate="@value"/>
<ClockZO  @bind-SelectDate="@value" />
```

#### Day Only
```
<DayZO  @bind-SelectDate="@value" />
```



#### year and month
```
<YearMonth   @bind-SelectDate="@value" />
```

#### chang format
Format="TypeFormat"
yyyy/MM/dd  Or  yy/MM/dd  Or  MMM  Or ddd Or ..
```
<ZeroOneDatePicker  Format="ddd D MMM سال yyyy ساعت hh:mm:ss"  />
```

# ![PersianDatePicker](https://raw.githubusercontent.com/AliRoostae/Blazor_PersianDatePickerZO/master/img/changeClock.gif)







