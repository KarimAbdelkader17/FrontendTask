   M S B A M L   `   `   `  ���� F  BUsersWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:UsersWpfAppUsersWpfApp      UsersWpfApp.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:UsersWpfApp       � Title$  
MainWindow��$��496.4��$	��800��.��� $	��420��$��
0,0,-0.4,0q�$	��Top=�.+��� -    ��Name$ startButton��$��Start Server��$
��Left=�$��658,105,0,0q�$	��Top=�$��75���� -   $ 
stopButton��$
��Stop��$
��Left=�$��658,153,0,0q�$	��Top=�$��75��&   System.Windows.Controls.DataGrid  -     Name$ usersDataGrid��$
��Left=�$	��356��$��	55,20,0,0q�$	��Top=�$	��429��   AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Email��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *email+  $ 	FirstName��$	 100  �� *
first_name+  $ LastName��$	 100  �� *	last_name+4  .System.Windows.Controls.DataGridTemplateColumn  $ 50    CellTemplate �� .R��� ���� *avatar+�� -   $ 
nextButton��$
��Next��$
��Left=�$��367,430,0,-29q�$	��Top=�$��75���� -   $ previousButton��$��Previous��$
��Left=�$��246,431,0,-30q�$	��Top=�$��75���� $��Pages��$
��Left=�$��45,427,0,-32q�$	��Top=��� -   	 ��Name$	 numPagesTextBox��$
��Left=�$��23��$��106,431,0,-34q�
 �� TextWrapping$

 Wrap=�$��0��$	��Top=�$��68��{�.  