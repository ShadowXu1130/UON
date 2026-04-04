# UON Access

**UON Access** is a professional native productivity solution developed with **.NET MAUI** for **University of Newcastle (UON)** students at the **PSB Academy** campus in Singapore. The app transforms the fragmented "7-step PDF process" of checking schedules into a seamless, one-click digital experience.

## 📱 Native Features (Teacher Requirements)

To meet the core project requirements, UON Access implements two key native hardware and ecosystem integrations:

1.  **Secure Microsoft Authentication (Identity Integration)**: 
    * Integrated with the **Microsoft Identity Platform (MSAL.NET)**.
    * Allows students to sign in securely using their official university **school accounts**.
    * Utilizes native browser brokering for a trusted and secure identity verification process.

2.  **Haptic Feedback & Native Vibration (Hardware Integration)**:
    * Implemented **Native Haptic Feedback** during the Log Out process.
    * When a user clicks "Log Out," the device triggers a physical vibration (Click type) to provide tactile confirmation of the action.
    * Enhances the "Native App" feel by providing immediate sensory feedback for critical user actions.

## 🚀 Key Capabilities

* **Dynamic Timetable Engine**: 
    * A custom-mapped grid system rendering a full **15-week academic calendar**.
    * Uses **DateTime math** to programmatically calculate class positions and durations for a perfect visual layout.
* **Personalized Dashboard**: 
    * Features a **Progress Manager** that tracks remaining classes for the week.
    * Includes a high-contrast **"True Black" theme** and color-coded modules for rapid visual scanning.
* **Secure Navigation Flow**: 
    * Utilizes **MAUI Shell** absolute routing (`//`) to reset navigation stacks, ensuring sensitive data is inaccessible after logout.

## 🛠 Tech Stack

* **Framework**: .NET MAUI (.NET 10.0)
* **IDE**: **Visual Studio 2026**
* **Language**: C#
* **Architecture**: MVVM (Model-View-ViewModel)
* **Libraries**: Microsoft Authentication Library (MSAL.NET), Microsoft.Maui.Devices (Haptics)

## 📁 Project Structure

* **`/Models`**: Data entities such as `ScheduleItem` and `ClassModel`.
* **`/Services`**: 
    * `AuthService.cs`: Manages MSAL authentication and secure token handling.
    * `TimetableService.cs`: Contains the core logic for processing schedule data.
* **`/Views`**: Native UI pages (LoginPage, HomePage, SettingsPage, etc.).
* **`/ViewModels`**: Logic layer connecting Data Models to XAML Views.

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
3.  **Deploy**: Select **Windows Machine** (for desktop demo) or a **Physical Android/iOS Device** (to experience Haptic Feedback). Press **F5**.

## 📈 Final Project Status

All project milestones have been successfully completed:
- [x] Core Architecture & Clean Code Structure.
- [x] **Native Feature 1**: MSAL Secure Login Integration.
- [x] **Native Feature 2**: Haptic Feedback/Vibration on Logout.
- [x] Dynamic 15-Week Timetable Grid Logic.
- [x] "True Black" High-Contrast UI Design.
- [x] Final Deployment Stability Testing (Windows/Android).

---

**Developer:** Xu Xinpeng  
**Student ID:** C3509979  
**Institution:** University of Newcastle (UON) / PSB Academy  
**Date:** April 4, 2026