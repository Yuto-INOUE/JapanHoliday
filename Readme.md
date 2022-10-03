# JapanHoliday

Utility library on Japanese holidays.
It conforms to the "Law Concerning National Holidays" *(国民の祝日に関する法律)* and covers the years from 1949 to 2039.

National holidays are subject to change due to future revisions of the law or government ordinances, so the output of this program is not guaranteed to be correct.

## Usage
```cs
var d = new DateTime(2020, 1, 13);
Console.WriteLine(JapanHoliday.IsHoliday(d)); // true
Console.WriteLine(JapanHoliday.GetHolidayName(d)); // 成人の日
```

## Licence
this software is licensed under the mit license
