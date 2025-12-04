# Travel and Accommodation Booking Platform API

This API provides a comprehensive set of endpoints for managing hotel bookings, user authentication, hotels, cities, rooms, reviews, and payments. It is designed for efficiency, scalability, and maintainability.

---

## Key Features

### 1. User Authentication
- **User Registration:** Create a new account.
- **User Login:** Secure login to access booking features.

### 2. Global Hotel Search
- **Search by Criteria:** Hotel name, room type, capacities, price, etc.
- **Detailed Results:** View detailed information for matching hotels.

### 3. Popular Cities Display
- Display top trending cities based on user visits.

### 4. Email Notifications
- Request invoices via email.
- Communicate booking status and details to users.

---
### 1. Login Page
- **Username** and **Password** fields
- Allows users to securely log in to access the platform

---

### 2. Home Page

#### 2.1 Search Functionality
- Central search bar with placeholder: `"Search for hotels, cities..."`
- Interactive calendar for **check-in** and **check-out** dates (auto-set to today and tomorrow)
- Adjustable controls for:
  - **Adults** (default: 2)
  - **Children** (default: 0)
- Room selection option (default: 1 room)

#### 2.2 Featured Deals
- Display 3-5 **hotels** with:
  - Thumbnail
  - Hotel name & location
  - Original & discounted prices
  - Star ratings

#### 2.3 Recently Visited Hotels
- Personalized display of last 3-5 hotels visited by the user
- Information includes:
  - Thumbnail
  - Hotel name
  - City
  - Star rating
  - Pricing details

#### 2.4 Trending Destinations
- Curated list of **top 5 most visited cities**
- Each city shows:
  - Thumbnail
  - City name

---

### 3. Search Results Page

#### 3.1 Filters
- Sidebar with filters for:
  - Price range
  - Star rating
  - Amenities
  - Room type (luxury, budget, boutique)

#### 3.2 Hotel Listings
- Infinite scroll of hotels matching search criteria
- Each hotel entry shows:
  - Thumbnail
  - Name
  - Star rating
  - Price per night
  - Short description

---

### 4. Hotel Page

#### 4.1 Visual Gallery
- High-quality images, viewable in **fullscreen mode**

#### 4.2 Detailed Information
- Hotel name
- Star rating
- Description or history
- Guest reviews
- Interactive map with hotel location and nearby attractions

#### 4.3 Room Availability
- List of available rooms:
  - Room type, description, images
  - Price per night
  - "Add to cart" option for easy booking

---

### 5. Secure Checkout and Confirmation

#### 5.1 User Information & Payment
- Collects:
  - Personal details
  - Payment method
  - Special requests or remarks
- Optional integration with **third-party payment providers**

#### 5.2 Confirmation Page
- Displays booking details:
  - Confirmation number
  - Hotel address
  - Room details
  - Check-in / check-out dates
  - Total price
- Provides options to:
  - Print or save as PDF
  - Send email with payment status and invoice
  
## API Endpoints

### **Authentication**
| Method | Endpoint | Description |
|--------|---------|------------|
| POST   | `/api/auth/login` | Login |
| POST   | `/api/auth/signup` | Register a new user |

---

### **Home**
| Method | Endpoint | Description |
|--------|---------|------------|
| GET    | `/api/home/search` | Search hotels based on query and filters |
| GET    | `/api/home/featured-deals` | Top 3-5 featured hotel deals |
| GET    | `/api/home/{userId}/recently-visited-hotels` | User's recently visited hotels |
| GET    | `/api/home/trending-destinations` | Top 5 trending cities |

---

### **Cities**
| Method | Endpoint | Description |
|--------|---------|------------|
| GET    | `/api/cities` | Get list of cities |
| POST   | `/api/cities` | Create a new city |
| GET    | `/api/cities/{cityName}` | Get details of a city by name |
| GET    | `/api/cities/{cityId}` | Get details of a city by ID |
| PUT    | `/api/cities/{cityId}` | Update a city |
| DELETE | `/api/cities/{cityId}` | Delete a city |

---

### **Hotels**
| Method | Endpoint | Description |
|--------|---------|------------|
| GET    | `/api/hotels` | Get all hotels |
| POST   | `/api/hotels` | Create a new hotel |
| GET    | `/api/hotels/{hotelId}` | Get hotel details |
| PUT    | `/api/hotels/{hotelId}` | Update hotel |
| DELETE | `/api/hotels/{hotelId}` | Delete hotel |
| GET    | `/api/hotels/{hotelId}/rooms` | Get all rooms in hotel |
| POST   | `/api/hotels/{hotelId}/rooms` | Create room in hotel |
| GET    | `/api/hotels/{hotelId}/rooms/{roomId}` | Get specific room |
| GET    | `/api/hotels/{hotelId}/bookings` | Get hotel bookings |

---

### **Payments**
| Method | Endpoint | Description |
|--------|---------|------------|
| GET    | `/api/payments/{paymentId}` | Get payment details |
| POST   | `/api/payments/confirm` | Confirm a payment |
| POST   | `/api/payments/cancel` | Cancel a payment |
| GET    | `/api/payments/{paymentId}/pdf` | Download payment invoice |

---

### **Rooms**
| Method | Endpoint | Description |
|--------|---------|------------|
| GET    | `/api/rooms` | Get paged list of rooms |
| POST   | `/api/rooms` | Create room |
| GET    | `/api/rooms/{roomId}` | Get room by ID |
| PUT    | `/api/rooms/{roomId}` | Update room |
| DELETE | `/api/rooms/{roomId}` | Delete room |

---

### **Carts**
| Method | Endpoint | Description |
|--------|---------|------------|
| POST   | `/api/carts` | Add room to cart |
| GET    | `/api/carts/{userId}` | Get paged cart items for user |
| DELETE | `/api/carts/{cartId}` | Remove item from cart |
| DELETE | `/api/carts/clear/{userId}` | Clear all items in cart |

---

### **Users**
| Method | Endpoint | Description |
|--------|---------|------------|
| GET    | `/api/users/{userId}` | Get user info |

---

## Technology Stack

- **C#** - Main programming language
- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - ORM for database
- **SQL Server** - Database
- **Swagger - API documentation
- **JWT Authentication** - Secure authentication
- **Clean Architecture**: Web, Infrastructure, Application, Domain layers
- **HTTPS** and **password encryption** for security

### Prerequisites
- .NET 8 SDK
- SQL Server instance with database
