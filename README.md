[![build and test](https://github.com/yazan-hamamdi/TravelAndAccommodationBookingPlatform/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/yazan-hamamdi/TravelAndAccommodationBookingPlatform/actions/workflows/build-and-test.yml)
# Travel and Accommodation Booking Platform API 

This API provides a comprehensive set of endpoints for managing hotel bookings, user authentication, hotels, cities, rooms, reviews, and payments. It is designed for efficiency, scalability, and maintainability.

## Key Features
﻿
# Travel and Accommodation Booking Platform API

This API provides a comprehensive set of endpoints for managing hotel bookings, user authentication, hotels, cities, rooms, reviews, and payments. It is designed for efficiency, scalability, and maintainability.

## Key Features

### 1. User Authentication
- **User Registration**: Create a new account
- **User Login**: Secure login to access booking features

### 2. Global Hotel Search
- **Search by Criteria**: Hotel name, room type, capacities, etc.
- **Detailed Results**: View detailed information for matching hotels

### 3. Popular Cities Display
- Display top trending cities based on user visits

### 4. Email Notifications
- Request invoices via email
- Communicate booking status and details to users

## API Features & Capabilities

### 1. Authentication & Authorization
- User login with JWT token generation
- Secure user registration
- Role-based access control

### 2. Search & Discovery

#### Hotel Search
- Search hotels by name, city, dates, and criteria
- Filter by price range, star rating, amenities, and room type
- Support for adults, children, and room count parameters
- Paginated results for efficient data retrieval

#### Featured Content
- Top 3-5 featured hotel deals with discount information
- Recently visited hotels tracking (up to 5 hotels per user)
- Trending destinations (top 5 most visited cities)

### 3. Hotel Management
- Complete CRUD operations for hotels
- Hotel details including:
  - Name, description, star rating
  - Location (address, coordinates)
  - Thumbnail and gallery images
  - Associated rooms and amenities
- Room availability checking
- Booking history per hotel

### 4. Booking & Cart System
- Add rooms to cart before checkout
- View and manage cart items
- Clear cart functionality
- Create bookings from cart items
- Booking confirmation with details

### 5. Payment Processing
- Payment confirmation workflow
- Payment cancellation support
- Payment details retrieval
- Invoice generation (PDF format)
- Email notifications for payment status

### 6. City & Location Management
- CRUD operations for cities
- City search by name or ID
- Thumbnail images for cities
- Associated hotels per city

## API Endpoints

### Authentication
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/auth/login` | Login |
| POST | `/api/auth/signup` | Register a new user |

### Home
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/home/search` | Search hotels based on query and filters |
| GET | `/api/home/featured-deals` | Top 3-5 featured hotel deals |
| GET | `/api/home/{userId}/recently-visited-hotels` | User's recently visited hotels |
| GET | `/api/home/trending-destinations` | Top 5 trending cities |

### Cities
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/cities` | Get list of cities |
| POST | `/api/cities` | Create a new city |
| GET | `/api/cities/{cityName}` | Get details of a city by name |
| GET | `/api/cities/{cityId}` | Get details of a city by ID |
| PUT | `/api/cities/{cityId}` | Update a city |
| DELETE | `/api/cities/{cityId}` | Delete a city |

### Hotels
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/hotels` | Get all hotels |
| POST | `/api/hotels` | Create a new hotel |
| GET | `/api/hotels/{hotelId}` | Get hotel details |
| PUT | `/api/hotels/{hotelId}` | Update hotel |
| DELETE | `/api/hotels/{hotelId}` | Delete hotel |
| GET | `/api/hotels/{hotelId}/rooms` | Get all rooms in hotel |

### Payments
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/payments/{paymentId}` | Get payment details |
| POST | `/api/payments/confirm` | Confirm a payment |
| POST | `/api/payments/cancel` | Cancel a payment |
| GET | `/api/payments/{paymentId}/pdf` | Download payment invoice |

### Rooms
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/rooms` | Get paged list of rooms |
| POST | `/api/rooms` | Create room |
| GET | `/api/rooms/{roomId}` | Get room by ID |
| PUT | `/api/rooms/{roomId}` | Update room |
| DELETE | `/api/rooms/{roomId}` | Delete room |

### Carts
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/carts` | Add room to cart |
| GET | `/api/carts/{userId}` | Get paged cart items for user |
| DELETE | `/api/carts/{cartId}` | Remove item from cart |
| DELETE | `/api/carts/clear/{userId}` | Clear all items in cart |

### Users
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/users/{userId}` | Get user info |

## Technology Stack

- **C#** - Main programming language
- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - ORM for database
- **SQL Server** - Database
- **Swagger** - API documentation
- **JWT Authentication** - Secure authentication

## Architecture

**Clean Architecture** with the following layers:
- Application
- Infrastructure Layer
- Domain Layer

## Security

- Password encryption
- JWT-based authentication

## Prerequisites

- .NET 8 SDK
- SQL Server instance with database
