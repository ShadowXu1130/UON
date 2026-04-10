# UON Access

**UON Access** is a professional native productivity solution developed with **.NET MAUI** for **University of Newcastle (UON)** students at the **PSB Academy** campus in Singapore. The app transforms the fragmented "7-step PDF process" of checking schedules into a seamless, one-click digital experience.

## 📱 Native Features (Teacher Requirements)

To meet the core project requirements, UON Access implements two key native hardware and ecosystem integrations, fully optimized for cross-platform stability:

1.  **Secure Microsoft Authentication (Identity Integration)**: 
    * Integrated with the **Microsoft Identity Platform (MSAL.NET)**.
    * Allows students to sign in securely using their official university **school accounts** via native browser brokering.
2.  **Haptic Feedback & Native Vibration (Hardware Integration)**:
    * Implemented **Native Haptic Feedback** during the Log Out process to provide immediate sensory confirmation.
    * **Cross-Platform Graceful Degradation:** If the app is tested on a device without a physical vibration motor (e.g., a Windows Desktop PC), the system safely catches the `FeatureNotSupportedException` and displays a native UI alert instead, preventing application crashes.

## 🧪 Examiner Guide: Test Mode (Demo Bypass)

Due to strict **University Azure AD tenant restrictions**, the official MSAL login flow may present a "Need admin approval" error for accounts not whitelisted by UON IT. 

To ensure examiners can fully grade and experience the application's core features without administrative roadblocks, a **Test Mode** has been architected into the Entry Point:
* **How to use:** On the initial Login Screen, click the **"Skip Login (Test Mode)"** button.
* **What it does:** It safely bypasses the MSAL token acquisition, dynamically injects mock `UserSession` state data (e.g., "Examiner Demo"), and routes the user directly to the main Dashboard.

## 🚀 Key Capabilities

* **Dynamic Timetable Engine**: 
    * A custom-mapped grid system rendering a full **15-week academic calendar**.
    * Uses **advanced DateTime algorithms** to programmatically calculate class positions (Grid Rows/Columns) and durations for a perfect visual layout.
* **Personalized Dashboard**: 
    * Features a **Progress Manager** that tracks remaining classes for the week.
    * Includes a high-contrast **"True Black" theme** and color-coded modules for rapid visual scanning.
* **Secure Navigation Flow**: 
    * Utilizes **MAUI Shell** absolute routing (`//`) to reset navigation stacks, ensuring sensitive data is inaccessible and preventing memory leaks after logout.

## 🛠 Tech Stack

* **Framework**: .NET MAUI (.NET 10.0)
* **IDE**: **Visual Studio 2026**
* **Language**: C#
* **Architecture**: **Data-Driven Code-Behind** with robust State Management (`UserSession`)
* **Libraries**: Microsoft Authentication Library (MSAL.NET), Microsoft.Maui.Devices (Haptics API)

## 📁 Project Structure

* **`/Models`**: Data entities such as `ScheduleItem` and `ClassModel`.
* **`/Services`**: 
    * `AuthService.cs`: Manages MSAL authentication and secure token handling.
    * `TimetableService.cs`: Contains the core logic for processing schedule data.
    * `UserSession.cs`: A global static state manager for secure user context handling.
* **`/Views`**: **Core Logic & UI Layer**. XAML pages combined with C# logic to handle user interactions, dynamic grid rendering, and hardware feedback.

## ⚙️ Getting Started

### Prerequisites
* **Visual Studio 2026** with the **.NET MAUI development** workload.
* .NET 10.0 SDK.

### Installation & Run
1.  **Clone the repository**:
    ```bash
    git clone [https://github.com/ShadowXu1130/UON.git](https://github.com/ShadowXu1130/UON.git)
    ```
2.  **Open in VS 2026**: Open `UON.sln`.
3.  **Deploy**: Select **Windows Machine** (for desktop demo) or a **Physical Android/iOS Device** (to experience native Haptic Feedback). Press **F5**.
4.  **Log In**: Click **"Skip Login (Test Mode)"** to bypass University IT restrictions and access the dashboard.

## 📈 Final Project Status

All project milestones have been successfully completed:
- [x] Optimized Code-Behind Architecture for direct hardware control.
- [x] **Native Feature 1**: MSAL Secure Login Integration.
- [x] **Native Feature 2**: Haptic Feedback/Vibration on Logout.
- [x] **Architecture**: Implementation of Test Mode and Hardware Fallback handling.
- [x] Dynamic 15-Week Timetable Grid Logic.
- [x] "True Black" High-Contrast UI Design.
- [x] Comprehensive XML Documentation and Git Version Control.

---

**Developer:** Xu Xinpeng  
**Student ID:** C3509979  
**Institution:** University of Newcastle (UON) / PSB Academy  
**Date:** April 2026
