# Smart Study Planner - Quick Reference Guide

## ?? NEW FEATURES AT A GLANCE

### 1?? Edit Profile
- **Location:** Form3Profile.vb
- **Button/Link:** "Upload Picture" LinkLabel
- **What It Does:** Edit Name, Gender, Department + Upload Profile Picture
- **Access:** Click link on profile page
- **Saves To:** DataStore + UserPictures folder

### 2?? View Registered Users
- **Location:** Form3Student.vb / Form3Instructor.vb
- **Shows:** ALL Instructors (Blue) + ALL Students (Green)
- **Information:** Name, Username, Department, Gender
- **Scrollable:** Yes, with AutoScroll enabled
- **Access:** Click on PEOPLE ? STUDENT or INSTRUCTOR

### 3?? Grade Management
- **Location:** Form6Grades.vb
- **INSTRUCTOR:** Enter scores for students (0-100)
- **STUDENT:** View assigned grades with percentage & letter grade
- **Automatic Calc:** Percentage & Letter Grade (A-F)
- **Color-Coded:** Green (A), Yellow (B), Blue (C), Orange (D), Red (F)
- **Access:** Click GRADES menu

---

## ?? IMPORTANT FILES

```
Grade.vb ..................... Grade data model
Subject.vb ................... Subject data model
Form3EditProfile.vb .......... Edit profile form
Form3Student.vb ............. Show users + view grades
Form3Instructor.vb .......... Show users + enter grades
Form6Grades.vb .............. Grade management interface
DataStore.vb ................. Database + file operations
```

---

## ?? DATABASE FILES CREATED

```
%APPDATA%\SmartStudyPlanner\data\
??? students.xml ............ Student accounts
??? instructors.xml ......... Instructor accounts
??? grades.xml .............. All grades
??? subjects.xml ............ All subjects

UserPictures\ ............... Profile pictures
??? username_profile.jpg
??? ...
```

---

## ?? USER FLOWS

### STUDENT LOGIN
1. Views registered users (Instructors & Students)
2. Clicks on profile to view/edit
3. Clicks GRADES to see assigned grades
4. Color indicates performance (Green=Good, Red=Poor)

### INSTRUCTOR LOGIN
1. Views registered users (Instructors & Students)
2. Clicks on GRADES
3. Enters scores for students
4. System auto-calculates percentage & grade letter
5. Saves immediately

---

## ??? DEVELOPER NOTES

### Adding a New Grade
```vb
Dim grade As New Grade(studentID, studentName, subjectID, subjectName, score)
DataStore.SaveGrade(grade)
```

### Loading Grades
```vb
Dim allGrades = DataStore.LoadGrades(subjectID)
Dim studentGrades = allGrades.Where(Function(g) g.StudentID = userID).ToList()
```

### Getting All Users
```vb
Dim students = DataStore.LoadUsers("Student")
Dim instructors = DataStore.LoadUsers("Instructor")
```

---

## ?? COLOR SCHEME

| Component | Color | Purpose |
|-----------|-------|---------|
| Instructor Panel | Light Blue | Distinguish instructors |
| Student Panel | Light Green | Distinguish students |
| Grade A | Light Green | Excellent |
| Grade B | Light Yellow | Good |
| Grade C | Light Sky Blue | Average |
| Grade D | Wheat | Below Average |
| Grade F | Light Coral | Fail |

---

## ?? CURRENT BUILD STATUS

? **Compilation:** Successful  
? **Features:** 4 Major + 2 Models  
?? **Classes:** 8 Forms + 2 Data Models  
?? **Database:** XML-based  

---

## ?? READY TO ADD NEXT

1. **Navigation Links** - Click subject ? go to tasks
2. **File Upload/Download** - Students submit tasks
3. **Deadline Management** - Set & track deadlines
4. **Calendar Integration** - View tasks by date

---

## ?? TROUBLESHOOTING

| Issue | Solution |
|-------|----------|
| UserPictures folder not found | Created automatically on first save |
| Grades not showing | Check student username matches |
| Users not appearing | Ensure registered in correct role |
| Build failed | Check DataStore imports (System.Linq) |

---

## ?? DATA SECURITY

- Passwords stored as-is (consider hashing in production)
- User pictures are separate from profile data
- Grades tied to username + subject ID
- All operations have error handling

---

**Last Updated:** Current Session  
**Version:** 2.0  
**Status:** Ready for Next Features

