Public Module Session
    Private _currentUser As User
    Private _selectedSubject As Subject

    Public Property CurrentUser As User
        Get
            Return _currentUser
        End Get
        Set(value As User)
            _currentUser = value
        End Set
    End Property

    Public Property SelectedSubject As Subject
        Get
            Return _selectedSubject
        End Get
        Set(value As Subject)
            _selectedSubject = value
        End Set
    End Property

    Public Sub LogOut()
        _currentUser = Nothing
        _selectedSubject = Nothing
    End Sub
End Module

