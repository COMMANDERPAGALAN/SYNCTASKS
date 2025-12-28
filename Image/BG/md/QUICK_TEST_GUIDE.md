# Quick Testing Checklist

## Pre-Pitch Testing (Run These 5 Minutes Before!)

### ? Test Registration
- [ ] Run application
- [ ] Click "Register" ? "Student"
- [ ] Fill form: FirstName=Demo, LastName=User, Gender=Male, Department=Engineering, Username=demo1, Password=pass123
- [ ] Click "SIGN UP"
- [ ] See success message? ?

### ? Test Login  
- [ ] Back to main screen
- [ ] Click "Login" ? "Student"
- [ ] Enter: demo1 / pass123
- [ ] Click "LOGIN"
- [ ] See main app dashboard? ?

### ? Test Duplicate Username Prevention
- [ ] Try registering another account with username "demo1"
- [ ] Should see error "Username already exists"? ?

### ? Test Wrong Credentials
- [ ] Try login with demo1 / wrongpassword
- [ ] Should see error message? ?

### ? Test Role Separation
- [ ] Register as Instructor with same username as Student
- [ ] Should work (different role)? ?

---

## Demo Flow for Pitch

1. **Start App** - Show welcome screen
2. **Show Registration** - Fill form and register (username: student_demo, password: demo123)
3. **Show Dashboard** - Display main application after login
4. **Show Data Storage** - Open file explorer, navigate to:
   ```
   C:\Users\[YourUsername]\AppData\Roaming\SmartStudyPlanner\data\students.xml
   ```
   Show the XML file with registered user data

5. **Show Login** - Go back and login with same credentials to verify persistence

---

## If Something Goes Wrong

### Issue: Registration button doesn't work
- Make sure you click the blue "SIGN UP" button (not the CANCEL button)
- Check that all fields are filled
- Look at debug output (Debug ? Windows ? Output)

### Issue: Login fails after registration
- Make sure you're selecting the same role for both registration and login
- Check the error message for hints (it shows file location and user count)
- Verify XML file exists in AppData folder

### Issue: User data not saved
- Run the app with administrative privileges
- Check folder permissions for AppData\SmartStudyPlanner
- Look in Output window for detailed error messages

### Issue: Build fails
- Clean solution (Build ? Clean Solution)
- Rebuild (Build ? Rebuild Solution)
- Check all files were updated

---

## Contact/Debug Info

If issues arise:
1. Check **Output** window in Visual Studio (Debug ? Windows ? Output)
2. Look for messages starting with "DataStore.LoadUsers" or "DataStore.RegisterNewUser"
3. Check file location shown in error messages
4. Verify XML files have correct permissions

**All files fixed and ready to go! ??**
