﻿using Festifact.Organisation.Services;

namespace Festifact.Organisation.ViewModel;

[QueryProperty(nameof(Show), (nameof(Show)))]
public partial class ShowEditViewModel : BaseViewModel
{
    [ObservableProperty]
    Show show;
}