﻿Imports System.Collections.Generic
Imports System.Text

Public Class SelectionHelper(Of KeyType)
    Dim selectedValues As Dictionary(Of KeyType, Boolean) = New Dictionary(Of KeyType, Boolean)
    Public Function GetIsSelected(ByVal key As KeyType) As Boolean
        Dim isSelected As Boolean
        If selectedValues.TryGetValue(key, isSelected) Then
            Return isSelected
        End If
        Return False
    End Function
    Public Sub SetIsSelected(ByVal key As KeyType, ByVal value As Boolean)
        If value Then
            selectedValues(key) = value
        Else
            selectedValues.Remove(key)
        End If
    End Sub
    Public Function GetSelectedKeys() As List(Of KeyType)
        Dim list As New List(Of KeyType)()
        For Each key As KeyType In selectedValues.Keys
            list.Add(key)
        Next key
        Return list
    End Function
    Public Function GetSelectedKeysAsString() As String
        Dim list As List(Of KeyType) = GetSelectedKeys()
        Dim str As New StringBuilder()
        For i As Integer = 0 To list.Count - 1
            str.AppendLine(list(i).ToString())
        Next i
        Return str.ToString()
    End Function
    Public Function GetSelectionCount() As Integer
        Return selectedValues.Count
    End Function
End Class
