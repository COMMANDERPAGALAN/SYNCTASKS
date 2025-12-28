# Testing Guide for User Registration and Login

## Issue: Cannot login after creating credentials

This guide will help diagnose why login is failing after registration.

## Steps to Test:

1. **Register a New User:**
   - Start the application
   - Click "REGISTER"
   - Select "Instructor" or "Student"
   - Fill in ALL fields:
     - First Name
     - Last Name
     - Gender (select Male or Female)
     - Department
     - Username (from TextBox7 - "I.D no. or Username")
     - Password (from TextBox8)
   - Click "SIGN UP"
   - **IMPORTANT:** Note the file path shown in the success message!

2. **Check if File Was Created:**
   - The success message will show where the file was saved
   - Go to that location in Windows Explorer
   - Look for `instructors.xml` or `students.xml`
   - Open the file and verify your data is there

3. **Try to Login:**
   - Close the application completely
   - Restart the application
   - Click "LOG IN"
   - Select the SAME role you registered with (Instructor or Student)
   - Enter your username and password
   - Click "LOG IN"

4. **Check Debug Information:**
   - If login fails, the error message will show:
     - File location
     - Whether file exists
     - Number of registered users
   - Use this information to diagnose the issue

## Common Issues:

1. **Files saved to different location:**
   - When running from Visual Studio, files are in: `bin\Debug\net9.0-windows\`
   - When running the .exe directly, files are next to the .exe
   - Make sure you check the CORRECT location

2. **Wrong role selected:**
   - Make sure you select the SAME role when logging in as when registering
   - Instructor data is in `instructors.xml`
   - Student data is in `students.xml`

3. **Username/Password mismatch:**
   - Username is case-insensitive
   - Password is case-sensitive
   - Make sure there are no extra spaces

## Debug Output:

Check the Visual Studio Output window (View > Output) for debug messages showing:
- Registration details
- File paths
- User counts
- Login validation results

