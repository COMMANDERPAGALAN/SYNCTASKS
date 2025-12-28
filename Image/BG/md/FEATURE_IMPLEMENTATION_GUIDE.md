# Smart Study Planner System - Feature Implementation Guide

## Summary of Requested Features

### 1. ? **Edit Profile Feature** (IMPLEMENTED)
**Location:** Form3EditProfile.vb
**Description:** Users can:
- Edit their Name, Gender, College Department
- Upload a profile picture (saved to UserPictures folder)
- Save changes to their profile
- Cancel edit without saving

**How to Access:** Add an "Edit Profile" button/link in Form3Profile.vb that opens Form3EditProfile

**Code Example:**
```vb
Dim editForm As New Form3EditProfile()
editForm.ShowDialog(Me)
```

---

### 2. **User Management - Show Registered Users** (READY TO IMPLEMENT)
**Location:** Form3Student.vb and Form3Instructor.vb
**Description:**
- When a STUDENT logs in: Shows list of all registered INSTRUCTORS and other STUDENTS
- When an INSTRUCTOR logs in: Shows list of all registered INSTRUCTORS and STUDENTS
- Display users in organized panels with scrollbar for many users
- Show: Name, Username, Department, Gender

**Implementation Strategy:**
- Modify Form3Student.vb to load and display all registered users
- Add scrollable panel with dynamic user cards
- Same design for all cards

---

### 3. **Navigation Links** (READY TO IMPLEMENT)
**Connections:**
- SUBJECT ? TASKS (Form4Tasks.vb)
- INSTRUCTOR link ? Opens selected instructor's profile
- STUDENT link ? Opens selected student's profile
- TASKS link ? Opens Form4Tasks.vb
- DEADLINE link ? Opens Form8Deadline.vb
- DURATION link ? Opens Form9Duration.vb
- CALENDAR link ? Opens Form10Calendar.vb

**Implementation:** Use LinkLabel click handlers to navigate between forms

---

### 4. **Grade Management** (READY TO IMPLEMENT)
**Location:** Form6Grades.vb
**Description:**
- **INSTRUCTOR Interface:**
  - Input scores/grades for each student
  - Automatic calculation of total scores
  - Save grades to database
  
- **STUDENT Interface:**
  - View grades given by instructors (READ-ONLY)
  - See total score calculation
  - See subject-wise breakdown

**Implementation:**
- Create GradeEntry class to store grades
- Add grade submission/viewing logic based on user role
- Apply calculation formula for total scores

---

### 5. **File Upload/Download - Tasks** (READY TO IMPLEMENT)
**Location:** Form4Tasks.vb
**Description:**
- **INSTRUCTOR:** 
  - Upload task documents/files
  - Download submissions from students
  - Track submission status
  
- **STUDENT:**
  - Download task files from instructor
  - Upload completed task/documents
  - See submission status

**Implementation:**
- Create Tasks folder structure
- Add file handling (Upload/Download buttons)
- Track submission timestamps
- Store: TaskID, StudentID, SubmissionDate, FilePath

---

### 6. **Deadline Management** (READY TO IMPLEMENT)
**Location:** Form8Deadline.vb
**Description:**
- INSTRUCTOR sets deadline for tasks
- Display countdown/deadline status
- Auto-populate calendar with tasks
- Alert students of approaching deadlines

**Implementation:**
- Add date-time picker for deadline
- Store: TaskID, Subject, Deadline, Status
- Calculate days remaining
- Sync with Calendar

---

### 7. **Calendar Integration** (READY TO IMPLEMENT)
**Location:** Form10Calendar.vb
**Description:**
- Display all tasks with deadlines
- Color-code: Past due (Red), Due Soon (Yellow), On Schedule (Green)
- Show task details on date click
- Mark completed tasks

**Implementation:**
- Use built-in MonthCalendar control
- Add custom painting for color-coding
- Display task info on date selection

---

### 8. **Dynamic Content Display** (READY TO IMPLEMENT)
**Description:**
- Multiple registered users ? Organized panels with scrollbar
- Multiple subjects ? Auto-add panels with same design
- Same applies to: TASKS, PROGRESS, GRADES, DEADLINE, DURATION

**Implementation Strategy:**
- Use FlowLayoutPanel or dynamically add panels
- Set AutoScroll = True
- Maintain consistent panel size and design
- Replicate styling for each item

---

## Database Model (Required Classes)

### Task Class
```vb
Public Class Task
    Public Property TaskID As String
    Public Property SubjectID As String
    Public Property Title As String
    Public Property Description As String
    Public Property InstructorID As String
    Public Property Deadline As DateTime
  Public Property FilePath As String
    Public Property CreatedDate As DateTime
End Class
```

### Grade Class
```vb
Public Class Grade
    Public Property GradeID As String
    Public Property StudentID As String
    Public Property SubjectID As String
    Public Property Score As Decimal
    Public Property TotalScore As Decimal
    Public Property Percentage As Decimal
    Public Property DateSubmitted As DateTime
End Class
```

### Subject Class
```vb
Public Class Subject
    Public Property SubjectID As String
    Public Property SubjectName As String
    Public Property InstructorID As String
    Public Property Department As String
    Public Property Description As String
End Class
```

---

## Implementation Priority Order

1. ? Edit Profile (DONE)
2. Show registered users in lists
3. Navigation links between forms
4. Grade input/viewing
5. File upload/download
6. Deadline management
7. Calendar integration
8. Dynamic responsive panels

---

## Key Files to Modify/Create

| File | Action | Priority |
|------|--------|----------|
| Form3Profile.vb | Add "Edit Profile" button | High |
| Form3Student.vb | Add user list display | High |
| Form3Instructor.vb | Add user list display | High |
| Form4Tasks.vb | Add file upload/download | High |
| Form6Grades.vb | Add grade input/display | High |
| Form8Deadline.vb | Add deadline management | Medium |
| Form10Calendar.vb | Add calendar integration | Medium |
| DataStore.vb | Add methods for tasks, grades, subjects | High |

---

## Next Steps

1. Implement "Edit Profile" button in Form3Profile
2. Modify Form3Student/Form3Instructor to show all registered users
3. Add navigation links between forms
4. Implement grade management system
5. Add file handling for tasks
6. Integrate deadlines with calendar

