# TechShop Management (C# WinForms)

An on-premise **shop management** desktop application built with **C# WinForms** and **SQL Server**.  
It supports multi-role access (Admin, Seller, Product Manager), basic inventory and sales operations, and revenue viewing.

---

## ✨ Features

- **Authentication & Roles**: Login with role-based routing to:
  - **Admin** – manage employees, customers, and products.
  - **Seller** – handle sales and product cart.
  - **Product Manager** – manage product catalog.
- **CRUD Operations**:
  - **Employees**: add/update/delete/search (`EmployeeList`).
  - **Customers**: add/update/delete/search (`CustomerList`).
  - **Products**: add/update/delete/search (`ProductList`).
  - **Sales**: add to cart, sell, record sold items (`ProductCartList`, `SoldProductList`).
- **Revenue View**: basic sales summary UI.
- **Password Obfuscation** using a simple custom `Encryption` helper.
- **Centralized Data Access** with `DataBaseAccess` (ADO.NET, `SqlConnection`).

---

## 🏗️ Architecture

```
UI (WinForms Forms)
 ├─ Login → routes to role dashboards
 ├─ Admin
 │   ├─ AdminEmployee
 │   ├─ AdminCustomer
 │   └─ AdminProduct
 ├─ Seller
 ├─ ProductManager
 └─ Revenue

Business / Controller
 ├─ ControlAdminCustomer
 ├─ ControlAdminEmployee
 └─ ControlAdminProduct

Data Access & Utilities
 ├─ DataBaseAccess.cs
 └─ Encryption.cs
```

---

## 📦 Project Structure

- **Solution:** `TechShopManagement.sln`
- **Project:** `TechShopManagement/TechShopManagement.csproj`
- **Main Entry:** `Program.cs` → `Application.Run(new Login());`
- **Resources:** `TechShopManagement/Resources/*` and `/image/*` (icons, show/hide graphics)

Total files: **82**  
Detected forms: `Login`, `Admin`, `Seller`, `ProductManager`, `Revenue`  
Tables used: `EmployeeList`, `CustomerList`, `ProductList`, `ProductCartList`, `SoldProductList`

---

## 🗄️ Database

- **Provider:** SQL Server (`System.Data.SqlClient`).
- **Connection:** Hard-coded in `DataBaseAccess.cs`. Update to match your SQL Server instance.
- **Schema File Included:** `shop_management.sql` (UTF-16, SSMS export).  
  Import into SQL Server to create all tables and constraints.

**Tables Defined in SQL Script:**
1. **CustomerList**
   - CustomerId `varchar(50)` **PK**
   - CustomerName `varchar(50)`
   - CustomerAddress `varchar(50)`
   - CustomerPhoneNumber `varchar(50)`
   - CustomerTotalExpense `numeric(18,2)`

2. **EmployeeList**
   - EmployeeId `varchar(50)` **PK**
   - EmployeePassword `varchar(50)`
   - EmployeeName `varchar(50)`
   - EmployeeRole `varchar(50)`
   - JobExperience `float`
   - JoiningDate `varchar(50)`
   - EmployeeDOB `varchar(50)`
   - EmployeeGender `varchar(50)`
   - EmployeeBloodGroup `varchar(50)`
   - EmployeePhoneNumber `varchar(50)`
   - EmployeeSalary `numeric(18,2)`
   - EmployeeAddress `varchar(50)`

3. **ProductCartList**
   - ProductId `varchar(50)` **PK**
   - ProductName `varchar(50)`
   - Price `numeric(18,2)`
   - Quantity `int`
   - TotalPrice `numeric(18,2)`

4. **ProductList**
   - ProductId `nvarchar(50)` **PK**
   - BrandName `nvarchar(50)`
   - ProductCategory `nvarchar(50)`
   - ProductName `nvarchar(50)`
   - Warranty `int`
   - Price `numeric(18,2)`
   - Quantity `int`
   - Description `nvarchar(50)` (nullable)

5. **SoldProductList**
   - PurchasedId `varchar(50)` **PK**
   - TotalPrice `numeric(18,2)`
   - CustomerId `varchar(50)` **FK → CustomerList.CustomerId**
   - PurchasedDate `varchar(50)`

---

## 🔐 Authentication & Security

- Passwords are stored in the DB after being processed with a simple obfuscation method (`Encryption.encrypt()` with key `"6291756464"`).
- **Not secure for production** — replace with salted hashes (e.g., PBKDF2, BCrypt, Argon2) and parameterized queries.

---

## ⚠️ Code Notes

- **SQL Injection Risk:** Queries are built by concatenating strings. Must switch to parameterized queries.
- **Tight Coupling:** UI and DB code mixed; consider separating layers.
- **Error Handling:** Basic `try/catch` only; logging recommended.
- **Hardcoded Connection:** Change in `DataBaseAccess.cs` before deployment.

---

## ▶️ Getting Started

1. **Install Prerequisites**
   - Visual Studio with **.NET Framework 4.7.2**
   - SQL Server or LocalDB

2. **Set Up Database**
   - Create database `TechShopManagement` in SQL Server.
   - Open `shop_management.sql` in SSMS, set the database context, and execute.

3. **Configure Connection String**
   - Edit `DataBaseAccess.cs`:
     ```csharp
     this.Sqlcon = new SqlConnection(@"Data Source=YOUR_SERVER;Initial Catalog=TechShopManagement;Integrated Security=True;");
     ```

4. **Run**
   - Build and run from Visual Studio.
   - Login using credentials from `EmployeeList` (Role: Admin/Seller/Product Manager).

---

## 📈 Future Improvements

- Use secure password hashing.
- Apply parameterized queries in all SQL.
- Add validation to UI forms.
- Provide seed/test data in SQL file.
- Implement role-based UI restrictions more strictly.


