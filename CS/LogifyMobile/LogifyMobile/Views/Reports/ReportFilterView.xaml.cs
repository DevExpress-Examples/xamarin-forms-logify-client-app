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
﻿using Xamarin.Forms;

namespace Logify.Mobile.Views {
    public partial class ReportFilterView : Grid {
        double statusGridRowSpacing;
        public ReportFilterView() {
            InitializeComponent();
            statusGridRowSpacing = statusGrid.RowSpacing;
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e) {
            grid.FilterString = $"Contains([Name], '{e.NewTextValue}')";
        }

        public void UnfocusFilterPanel() {
            teamsPicker.UnfocusPicker();
            subscriptionsPicker.UnfocusPicker();
        }
        public void ChangeLandscapeMode(bool landscape) {
            appsStatusStack.Orientation = landscape ? StackOrientation.Horizontal : StackOrientation.Vertical;
            statusDivider.IsVisible = landscape ? false : true;
            statusGrid.RowSpacing = landscape ? 0 : statusGridRowSpacing;
        }
    }
}
