   M S B A M L   `   `   `  ????J  FCargoCompanyWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CargoCompanyWPF.ViewCargoCompanyWPF.View  5      E'clr-namespace:CargoCompanyWPF.ViewModelCargoCompanyWPF.ViewModel  5      $    CargoCompanyWPF.View.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:CargoCompanyWPF.View     5      =	viewModel'clr-namespace:CargoCompanyWPF.ViewModel     5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a<mD1http://materialdesigninxaml.net/winfx/xaml/themes   5      -   5        $??
MyHomeView??5         MaterialDesignBody#???   5
      $??Regular"?5      $??14(?5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5         TextRenderingMode$
 Auto=?5        MaterialDesignPaper#???  5        MaterialDesignFont#???  5      $	??700??5      $	??800??6   .??5      ? .+?5   
   ?? $??50??6   $??30(?6    $	??100??6.   $??E-mail??6:   $??32,193,668,457q?6H   6b   ?? 5   
   $??20(?67   $??289,236,219,436q?6E   $
{?True??6^   ??6   ?? *Error.Email_error+6^   ?? 5   
   $??20(?6:   $??284,338,224,335q?6H   $
{?True??6a   ??6   ?? *Error.Password_error+6a   ?? 5   
   $??Login??6   ${?False??6!   $
??Bold"?63   $
??Left=?6E   $	??Top=?6`   $??40(?6y   $??
345,48,0,0q?6?   $??59??6?   $	??122??6?   ?? 5   
   $
??Left=?6   $	??Top=?6.   $??184,176,0,0q?6b   $??35(?6w   $	??388??6?   ??6F   ?? *
User.Email+6?   ?? 5   
   $
??Left=?6   $	??Top=?6.   $??185,276,0,0q?6e   $??35(?6z   $	??388??6?   ??6F   ?? *User.Password+6?   ?? 5   
   -   5         ??Name$ login??5   )   $??50??6   $	??170??6   $??Bottom=?6Y   $??Login??6q   $??279,509,313,143q?6?   $??20(?6?   ??68   ?? *LoginCommand+6?   ?? 5   
   -   5        $ notauser??5      $	??118??6@   $
??Left=?6L   $??Not a user???6h   $??325,588,0,80q?6~    J? RenderTransformOrigin$ 0.485,0.036&?6?   ??6#   ?? *
Not_user+6?   ?? 5   
   $??50??6   $??30(?6    $??Password??6.   $??32,288,624,362q?6>   5       5!      