# CSE445 Project 5 – HoopHub Web Application

This project is a sports web application for creating and running intramural/recreational basketball leagues.

---

## Team Members

| Name              | Role                      |
|-------------------|---------------------------|
| Cyler Minkus      | PlayerService, GUI, Local Components |
| Lewin Elep        | LeagueService, CryptoUtils, Global.asax |
| Chris Schroeder   | TeamService, Cookie Logic, DLL Utils |

---

## Technologies Used

- ASP.NET Web Forms (C#)
- ASMX Web Services
- User Controls (`.ascx`)
- Session + Application State
- Cookies
- DLL Component Integration
- SHA-256 Hashing (CryptoUtils)

---

## Project Structure

- `Default.aspx` – Main GUI and test harness (TryIt page)
- `Services/PlayerService.asmx` – Player stat service
- `UserControls/LoginControl.ascx` – Simulated login panel
- `App_Code/CryptoUtils.cs` – SHA-256 hashing DLL component
- `Global.asax` – Application session tracking

---

## Notes

- All Web Services are interactive and testable through the GUI
- Local components (cookies, session, DLL) include labels and buttons for TryIt testing
- The deployed URLs are public and can be accessed for grading
---
