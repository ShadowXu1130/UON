# UON Access

**UON Access** is a mobile application developed with **.NET MAUI** specifically for **University of Newcastle (UON)** students at the **PSB Academy** campus in Singapore. The app serves as a centralized hub to consolidate fragmented campus services into a single, mobile-first interface.

## 🚀 Key Features

* **Secure Microsoft Authentication**: Integrated with **Microsoft Entra ID (MSAL)**, allowing students to sign in securely using their official university credentials.
* **Dynamic Timetable Engine**: 
    * A custom-mapped grid system that renders a full **15-week academic calendar**.
    * Automatically calculates class positions and durations using a specialized coordinate algorithm.
    * Includes coverage for public holidays and examination periods.
* **Personalized Dashboard**: Features contextual greetings (Morning/Afternoon/Evening) and real-time tracking of remaining classes for the week.
* **Secure Navigation Flow**: Utilizes **MAUI Shell** absolute routing (`//`) to reset navigation stacks upon login/logout, preventing unauthorized "back-button" access to sensitive data.

## 🛠 Tech Stack

* **Framework**: .NET MAUI (.NET 10.0)
* **Language**: C#
* **Architecture**: MVVM (Model-View-ViewModel)
* **Identity Provider**: Microsoft Authentication Library (MSAL.NET)
* **UI/UX**: XAML with custom Grid-mapping logic

## 📁 Project Structure

* **`/Models`**: Data entities such as `ScheduleItem` and `UserSession`.
* **`/Services`**: 
    * `AuthService.cs`: Manages MSAL authentication logic.
    * `TimetableService.cs`: Contains the 15-week academic dataset and retrieval logic.
* **`/Views`**: XAML pages including `LoginPage`, `HomePage`, and `TimetablePage`.
* **`/Resources`**: Application branding, including the custom **UON Access** icon and splash screen.
* **`AppShell.xaml`**: Defines the visual hierarchy and secure routing of the application.

## ⚙️ Getting Started

### Prerequisites
* Visual Studio 2022 with the **.NET MAUI development** workload installed.
* .NET 10.0 SDK.

### Installation
1.  **Clone the repository**:
    ```bash
    git clone [https://github.com/ShadowXu1130/UON.git](https://github.com/ShadowXu1130/UON.git)
    ```
2.  **Restore dependencies**:
    ```bash
    dotnet restore
    ```
3.  **Run the application**:
    Select your target platform (Android, iOS, or Windows) in Visual Studio and press **F5**.

## 📈 Current Status

Development is **ahead of schedule**. Current milestones reached:
- [x] Core MVVM Architecture setup.
- [x] MSAL Integration & Secure Session Management.
- [x] 15-Week Dynamic Timetable Engine implementation.
- [x] Personalized UI/UX logic.
- [ ] Live Data API Integration (Upcoming).

---

**Developer:** Xu Xinpeng  
**Student ID:** C3509979  
**Institution:** University of Newcastle (UON) / PSB Academy
