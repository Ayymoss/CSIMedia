* Allow the user to enter a variable amount of numbers, of any integer value and in random order. **DONE**
* Sort these numbers in either ascending or descending order – the user should choose the order. **DONE**
* The ordered sequence should be inserted into the database along with the direction that the sequence was sorted in and the time taken to perform the sort. **DONE**
* Feedback to the user the result of the operation (i.e., whether the operation was successful, any validation issues with the submission or any errors that occurred). **DONE**
* Display the results of all sorts including the sort direction and time taken. **DONE**
* Allow the user to export all of the sorts as JSON. **DONE**
* Please document all assumptions and decisions taken separately and submit with final codebase. **DONE**

# Assumptions and Decisions
* Decision: I've capped the user input to 32 max numbers.
* Decision: For brevity, I'm storing as `int[]` (`EFNumbers.Numbers`) instead of storing in a dedicated table with a foreign key relationship to the main table row entry.
* Decision: Try-Catching `int.Parse()` to handle non-integer input.
* Decision: Preference for EFCore Entity prefix `EF`. Using Resharper comment to suppress naming convention suggestion.
* Decision: Preference to not use top-level statement setup for `Program.cs`.
* Assuming: CSV for input. Spaces and trailing commas are stripped.
* Assuming: Use of `.OrderBy()` and `.OrderByDescending()` since instructions did not specify a required custom solution.

Note, I spent about 2 1/2 to 3 hours on this.

