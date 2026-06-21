using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MatrixIncBezorgApp.Models;

public class BerichtItem : INotifyPropertyChanged
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Onderwerp { get; set; } = string.Empty;
    public string Bericht { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public DateTime Datum { get; set; }

    private bool _isExpanded;

    public bool IsExpanded
    {
        get => _isExpanded;
        set
        {
            if (_isExpanded != value)
            {
                _isExpanded = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}