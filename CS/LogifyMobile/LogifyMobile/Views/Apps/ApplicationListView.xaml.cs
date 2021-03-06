/*
               Copyright (c) 2015-2020 Developer Express Inc.
{*******************************************************************}
{                                                                   }
{       Developer Express Mobile UI for Xamarin.Forms               }
{                                                                   }
{                                                                   }
{       Copyright (c) 2015-2020 Developer Express Inc.              }
{       ALL RIGHTS RESERVED                                         }
{                                                                   }
{   The entire contents of this file is protected by U.S. and       }
{   International Copyright Laws. Unauthorized reproduction,        }
{   reverse-engineering, and distribution of all or any portion of  }
{   the code contained in this file is strictly prohibited and may  }
{   result in severe civil and criminal penalties and will be       }
{   prosecuted to the maximum extent possible under the law.        }
{                                                                   }
{   RESTRICTIONS                                                    }
{                                                                   }
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }
{   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   }
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING         }
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }
{                                                                   }
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }
{   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      }
{                                                                   }
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }
{   ADDITIONAL RESTRICTIONS.                                        }
{                                                                   }
{*******************************************************************}
*/
﻿using Logify.Mobile.ViewModels;
using Xamarin.Forms;

namespace Logify.Mobile.Views {
    public partial class ApplicationListView : ContentPage {
        TeamsViewModel teamsViewModel = TeamsViewModel.Instance;

        public ApplicationListView() {
            InitializeComponent();
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            MessagingCenter.Send<Page, bool>(this, EventNames.SET_APPS_ARE_GESTURES_ENABLED, true);
            teamsViewModel.PropertyChanged += Settings_PropertyChanged;
        }
        protected override void OnDisappearing() {
            base.OnDisappearing();
            MessagingCenter.Send<Page, bool>(this, EventNames.SET_APPS_ARE_GESTURES_ENABLED, false);
            teamsViewModel.PropertyChanged -= Settings_PropertyChanged;
        }
        void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == nameof(PickerViewModelBase.SelectedItem)) {
                ((ApplicationListViewModel)BindingContext).RefreshCommand?.Execute(this);
            }
        }
        async void Handle_Tap(object sender, DevExpress.XamarinForms.DataGrid.DataGridGestureEventArgs e) {
            if(e.Item != null)
                await Application.Current.MainPage.Navigation.PushAsync(new ApplicationDetailsView() { BindingContext = e.Item });
        }
    }
}
