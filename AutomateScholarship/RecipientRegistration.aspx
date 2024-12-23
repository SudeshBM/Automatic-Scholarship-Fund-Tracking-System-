<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipientRegistration.aspx.cs" Inherits="AutomateScholarship.RecipientRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="zxx">
<head>
    <title>Automate Scholarship System</title>
    <!-- Meta tag Keywords -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="UTF-8" />
    <meta name="keywords" content="Flat lay login form Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
    <!-- //Meta tag Keywords -->
    <%--<link href="//fonts.googleapis.com/css2?family=Nunito:wght@300;400;600&display=swap" rel="stylesheet">--%>
    <!--/Style-CSS -->
    <link rel="stylesheet" href="css/style_css.css" type="text/css" media="all" />
    <!--//Style-CSS -->
    <%--<script src="https://kit.fontawesome.com/af562a2a63.js" crossorigin="anonymous"></script>--%>
</head>
<body>
    <!-- form section start -->
    <section class="w3l-workinghny-form">
        <!-- /form -->
        <div class="workinghny-form-grid">
            <div class="wrapper">
                <div class="logo">
                    <h1><a class="brand-logo" href="RecipientRegistration.aspx">Recipient Registration form</a></h1>
                    <!-- if logo is image enable this   
                        <a class="brand-logo" href="#index.html">
                            <img src="image-path" alt="Your logo" title="Your logo" style="height:35px;" />
                        </a> -->
                </div>
                <div class="workinghny-block-grid">
                    <div class="form-right-inf">
                       
                        <div class="login-form-content">
                            <%--<h2>Login with email</h2>--%>
                              <form id="form1" runat="server">
                        
                <div class="form-group">
                    <label for="exampleInputEmail1">
                        Enter Name</label><asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Name"
                        ControlToValidate="txtName" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">
                        Enter EmailId</label><asp:TextBox ID="txtEmailId" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter EmailId"
                        ControlToValidate="txtEmailId" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email Id"
                        ControlToValidate="txtEmailId" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="A"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">
                        Enter MobileNo</label><asp:TextBox ID="txtMobileNo" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter MobileNo"
                        ControlToValidate="txtMobileNo" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only 10 Digits"
                        ControlToValidate="txtMobileNo" ForeColor="Red" ValidationExpression="[0-9]{10}"
                        ValidationGroup="A"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="exampleInputEmail1">
                        Enter Address</label><asp:TextBox ID="txtAddress" class="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Address"
                        ControlToValidate="txtAddress" ForeColor="Red" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>
                        Select Photo</label>
                    <asp:FileUpload ID="PhotoFile" class="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Select File"
                        ForeColor="Red" ValidationGroup="A" ControlToValidate="PhotoFile"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                 <asp:Button runat="server" Text="Register" ID="btnRegister" class="btn btn-style mt-3"  
                                    ValidationGroup="A" onclick="btnRegister_Click"
                        ></asp:Button>
                        <asp:Button runat="server" Text="Home" ID="btnHome" class="btn btn-style mt-3" onclick="btnHome_Click"></asp:Button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- //form -->
        <!-- copyright-->
        <div class="copyright text-center">
            <div class="wrapper">
                <p class="copy-footer-29">© 2024 Automate Scholarship System. All rights reserved | Design by Automate Scholarship System</p>
            </div>
        </div>
        <!-- //copyright-->
    </section>
    <!-- //form section start -->
</body>
</html>
