🌍 Travel Itinerary Planner — Console App
A crisp, educational C# console app that showcases a custom generic dynamic array (CustomArray<T>) while managing travel Destinations (name, country, description).
Learn arrays, generics, resizing, searching, and removing — without leaning on List<T>.





✨ Highlights
Custom generic array CustomArray<T>
Add, search, remove, index, enumerate, print, convert to real arrays — plus auto-resize and manual Resize(int).

Type-agnostic by design
Works with Destination, int, string, or your own types.

Clean, documented code
XML comments + targeted inline notes for IntelliSense and easy grading.

Simple interactive menu
Add / list / search / remove destinations; also a quick demo with CustomArray<int>.

🧭 Why a Custom Array?
Understand how dynamic arrays work: backing storage, capacity vs count, amortized growth.

Practice generics and equality comparers for robust search/remove.

Build intuition for time complexity and memory trade-offs.

🗂️ Project Structure
cpp
Copy
Edit
TravelItineraryPlanner/
├─ Program.cs          // Console menu/UI
├─ CustomArray.cs      // Generic dynamic array (core of the assignment)
└─ Destination.cs      // Destination model + NameCountryComparer
⚙️ Getting Started
Prerequisites
Visual Studio 2022+ with .NET SDK 6/7/8, or just the .NET SDK + terminal.

Setup
Create a Console App project named TravelItineraryPlanner.

Add the three files above (Program.cs, CustomArray.cs, Destination.cs).

Build & run.

bash
Copy
Edit
dotnet build
dotnet run
🖥️ Using the App
You’ll see a menu like:

pgsql
Copy
Edit
=== Travel Itinerary Planner ===
1) Add destination
2) List destinations
3) Search destination by name
4) Remove destination by name
5) Demo: use CustomArray<int>
0) Exit
Add: Enter Name, Country, Description

List: View [index: value] format

Search: Case-insensitive by Name

Remove: Removes first matching Name

Demo: See CustomArray<int> auto-resize & remove

🧩 API Snapshot — CustomArray<T>
Member	What it does
Count / Capacity	Logical size vs allocated storage
this[int index]	Fast indexer get/set
Add(T item)	Appends; auto-resizes as needed
IndexOf(T, IEqualityComparer<T>?)	Linear search; returns index or -1
Contains(T, IEqualityComparer<T>?)	Convenience over IndexOf
Find(Predicate<T>)	First match or default
Remove(T, IEqualityComparer<T>?)	Removes first match (shifts tail)
RemoveAt(int index)	Removes by index (shifts tail)
Clear()	Clears elements; keeps capacity
Output()	Prints index: value (handy for demos)
Resize(int newCapacity)	Manual pre-allocation (≥ Count)
ToArray()	Tightly-sized copy

Complexity (amortized):
Add: O(1) average (O(n) only when growing) · Search/Remove: O(n) · Indexer: O(1)

🧠 Model — Destination
Immutable: Name, Country, Description (trimmed, null-safe)

ToString(): Name (Country) — Description

Logical equality (optional): Destination.NameCountryComparer (case-insensitive Name + Country)
Handy for accurate search/remove semantics.

🌱 Extend It (Optional)
TrimExcess() to shrink capacity to Count

AddRange(IEnumerable<T>) for bulk inserts

Edit destination details via an “Update” menu

Save/Load itinerary from JSON (e.g., System.Text.Json)

Unit tests with xUnit (CustomArray<T> behavior + edge cases)

📌 Example Snippets
Using CustomArray<Destination>
csharp
Copy
Edit
var itinerary = new CustomArray<Destination>();
itinerary.Add(new Destination("Paris", "France", "Eiffel Tower"));
itinerary.Add(new Destination("Tokyo", "Japan", "Shinjuku at night"));
itinerary.Output();

itinerary.Remove(new Destination("PARIS", "FRANCE", ""),
                 Destination.NameCountryComparer);
Using CustomArray<int>
csharp
Copy
Edit
var nums = new CustomArray<int>(2);
nums.Add(10);
nums.Add(20);
nums.Add(30); // triggers auto-resize
nums.Resize(64); // manual pre-allocation
nums.Output();
📝 References
Solid, reputable sources for arrays, generics, equality, and collection design.

Microsoft Learn — C# Arrays
https://learn.microsoft.com/dotnet/csharp/programming-guide/arrays/

Microsoft Learn — Generics in C#
https://learn.microsoft.com/dotnet/csharp/programming-guide/generics/

.NET API — IEqualityComparer<T>
https://learn.microsoft.com/dotnet/api/system.collections.generic.iequalitycomparer-1

.NET API — List<T> (for conceptual comparison)
https://learn.microsoft.com/dotnet/api/system.collections.generic.list-1

Microsoft Learn — Guidelines for Collections
https://learn.microsoft.com/dotnet/standard/design-guidelines/guidelines-for-collections

Cormen, T. H., Leiserson, C. E., Rivest, R. L., & Stein, C. (2022). Introduction to Algorithms (4th ed.). MIT Press.
(Amortized analysis & dynamic arrays)

Albahari, J., & Albahari, B. (2024). C# 12 in a Nutshell. O’Reilly Media.
(Modern C# features & patterns)

Skeet, J. (2019). C# in Depth (4th ed.). Manning.
(Deep dive into C# language & best practices)

📄 License
MIT — use, learn, and adapt freely. Add a LICENSE file if you’re submitting to GitHub/class.

🤝 Acknowledgements
Built as a focused learning artifact for Data Structures (arrays, generics, resizing) with a relatable travel use case. Happy exploring! ✈️
