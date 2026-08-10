MehmetAskerPortApp

A portfolio website with its own admin panel, built with ASP.NET Core 8 MVC.
Every section of the public page hero, about, resume, services, projects, testimonials, and contact  is managed through the admin panel and dynamically rendered from the database.
This project is a training project developed under the guidance of Murat Yücedağ and Erhan Gündüz at M&Y Yazılım Eğitim Akademi. The structure and overall approach of the project are based on the training I received.

I wrote the code myself and also incorporated my own decisions and improvements throughout the development process. For example, I replaced Bootstrap with Tailwind CSS in the admin panel and continued developing the project by adding my own ideas and improvements based on the vision provided during the training.
Features
Public Site
Single-page portfolio website rendered entirely from the database
Seven different sections, each implemented as its own ViewComponent
Animated network canvas effect in the hero section
Contact form with anti-forgery protection
Contact form submission using fetch
Toast notification after form submission
Post/Redirect/Get (PRG) fallback when JavaScript is disabled
Admin Panel
Cookie-based authentication
Global Authorization Filter protecting the entire application
Only the public page and login page are excluded from authorization

Full CRUD operations for all content entities:

About
Banner
Contact Info
Education
Experience
Project
Tech Stack
Service
Skill
Testimonial
Admin

Many-to-many relationship between Projects and Tech Stacks
Multiple technologies can be selected using a multi-select in the project form
Technologies used in projects are displayed as tags in the project list
Inbox system for contact messages:
Unread messages are displayed first
Unread message count displayed with a badge
Mark messages as read
Delete messages
Image upload system for banners, projects, and profile content
Tech Stack
Framework: ASP.NET Core 8 MVC
Database: SQL Server + Entity Framework Core 8
Database Approach: Code First + Migrations
Authentication: Cookie Authentication + Claims
Session: Sliding 30-minute expiration

Admin UI: Tailwind CSS, Dark Theme
Public UI: Hand-written CSS with Canvas animation
Architecture
The page structure is divided into multiple ViewComponents instead of being implemented as one large View.
This allows each section of the page to load its own data independently and be reused when necessary.
Each section is designed with its own responsibility. For example:
The Hero section loads its own data.
The About section loads its own data.
The Resume section manages education and experience information.
Projects are displayed together with their related technologies.

Services are implemented as a separate ViewComponent.
Skills are implemented as a separate ViewComponent.
Testimonials are implemented as a separate ViewComponent.
The Contact section manages its own data.
With this approach, the project avoids becoming complex inside a single large View and instead provides a modular, maintainable, and extensible architecture.
