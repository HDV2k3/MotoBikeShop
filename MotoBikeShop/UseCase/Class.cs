//@* < !--Single Page Header start -->
//<div class= "container-fluid page-header py-5" >

//    < h1 class= "text-center text-white display-6" > Shop Detail </ h1 >

//    < ol class= "breadcrumb justify-content-center mb-0" >

//        < li class= "breadcrumb-item" >< a href = "#" > Home </ a ></ li >

//        < li class= "breadcrumb-item" >< a href = "#" > Hàng hóa </ a ></ li >

//        < li class= "breadcrumb-item active text-white" > @Model.TenHh </ li >

//    </ ol >
//</ div >
//< !--Single Page Header End -->
//<!-- Single Product Start -->
//<div class= "container-fluid py-5 mt-5" >

//    < div class= "container py-5" >

//        < div class= "row g-4 mb-5" >

//            < div class= "col-lg-8 col-xl-9" >

//                < div class= "row g-4" >

//                    < div class= "col-lg-6" >

//                        < div class= "border rounded" >

//                            < a asp - action = "Detail"asp - route - id = "@Model.MaHh" >

//                                < img src = "~/images/@Model.Hinh" class= "img-fluid rounded" alt = "@Model.TenHh" >

//                            </ a >

//                        </ div >

//                    </ div >

//                    < div class= "col-lg-6" >

//                        < h4 class= "fw-bold mb-3" > @Model.TenHh </ h4 >

//                        < p class= "mb-3" > Category: @Model.TenLoai </ p >

//                        < h5 class= "fw-bold mb-3" > @Model.DonGia.ToString("#,##0.00") </ h5 >

//                        < div class= "d-flex mb-4" >

//                            < i class= "fa fa-star text-secondary" ></ i >

//                            < i class= "fa fa-star text-secondary" ></ i >

//                            < i class= "fa fa-star text-secondary" ></ i >

//                            < i class= "fa fa-star text-secondary" ></ i >

//                            < i class= "fa fa-star" ></ i >

//                        </ div >

//                        < p class= "mb-4" > @Model.MoTaNgan </ p >

//                        < form asp - action = "AddToCart" asp - controller = "Cart" asp - route - id = "@Model.MaHh" >

//                            < div class= "input-group quantity mb-5" style = "width: 100px;" >

//                                < div class= "input-group-btn" >

//                                    < button class= "btn btn-sm btn-minus rounded-circle bg-light border" type = "button" >

//                                        < i class= "fa fa-minus" ></ i >

//                                    </ button >

//                                </ div >

//                                < input type = "text" class= "form-control form-control-sm text-center border-0" value = "1" name = "quantity" >

//                                < div class= "input-group-btn" >

//                                    < button class= "btn btn-sm btn-plus rounded-circle bg-light border" type = "button" >

//                                        < i class= "fa fa-plus" ></ i >

//                                    </ button >

//                                </ div >

//                            </ div >

//                            < button class= "btn border border-secondary rounded-pill px-4 py-2 mb-4 text-danger" >< i class= "fa fa-shopping-bag me-2 text-danger" ></ i > Mua hàng </ button >

//                        </ form >

//                    </ div >

//                    < div class= "col-lg-12" >

//                        < nav >

//                            < div class= "nav nav-tabs mb-3" >

//                                < button class= "nav-link active border-white border-bottom-0" type = "button" role = "tab"

//                                        id = "nav-about-tab" data - bs - toggle = "tab" data - bs - target = "#nav-about"

//                                        aria - controls = "nav-about" aria - selected = "true" >
//                                    Thông tin hàng hóa
//								</button>
//								<button class= "nav-link border-white border-bottom-0" type = "button" role = "tab"

//                                        id = "nav-mission-tab" data - bs - toggle = "tab" data - bs - target = "#nav-mission"

//                                        aria - controls = "nav-mission" aria - selected = "false" >
//                                    Nhận Xét Từ Khách
//								</button>
//							</div>
//						</nav>
//						<div class= "tab-content mb-5" >

//                            < div class= "tab-pane active" id = "nav-about" role = "tabpanel" aria - labelledby = "nav-about-tab" >
//                                @Model.ChiTiet
//                            </ div >

//                            < div class= "tab-pane" id = "nav-mission" role = "tabpanel" aria - labelledby = "nav-mission-tab" >

//                                < div class= "d-flex" >
//                                    @await Component.InvokeAsync("Review")
//                                </ div >

//                            </ div >


//                        </ div >

//                    </ div >

//                    < form action = "/Review/SubmitReview" method = "post" >

//                        < h4 class= "mb-5 fw-bold" > Nhận Xét </ h4 >

//                        < div class= "row g-4" >

//                            < div class= "col-lg-6" >

//                                < div class= "border-bottom rounded" >

//                                    < input type = "text" class= "form-control border-0 me-4" placeholder = "Họ Và Tên *" name = "fullName" >

//                                </ div >

//                            </ div >

//                            < div class= "col-lg-12" >

//                                < div class= "border-bottom rounded my-4" >

//                                    < textarea class= "form-control border-0" cols = "30" rows = "8" placeholder = "Đánh Giá Của Bạn *" spellcheck = "false" name = "review" ></ textarea >

//                                </ div >

//                            </ div >

//                            < div class= "col-lg-12" >

//                                < div class= "d-flex justify-content-between py-3 mb-5" >

//                                    < button  type = "submit" class= "btn border border-secondary text-danger rounded-pill px-4 py-3" > Nhận Xét </ button >

//                                </ div >

//                            </ div >

//                        </ div >

//                    </ form >

//                </ div >

//            </ div >

//            < div class= "col-lg-4 col-xl-3" >

//                < div class= "row g-4 fruite" >

//                    < div class= "col-lg-12" >
//                        @await Html.PartialAsync("_TimKiemPanel")

//                        @await Component.InvokeAsync("MenuLoai")
//                    </ div >

//                    < div class= "col-lg-12" >

//                        < h4 class= "mb-4" > Sản Phẩm Tương Tự</h4>
//						@await Component.InvokeAsync("SanPhamTT", new { maloai = Model.MaLoai })

//                        < div class= "d-flex justify-content-center my-4" >

//                            < a asp - action = "Index" asp - controller = "HangHoa" class= "btn border border-secondary px-4 py-3 rounded-pill text-danger w-100" > Xem Thêm </ a >

//                        </ div >

//                    </ div >

//                </ div >

//            </ div >

//        </ div >

//        < h1 class= "fw-bold mb-0" > Các Sản Phẩm Khác</h1>
//		<div class= "vesitable" >

//            < div class= "owl-carousel vegetable-carousel justify-content-center" >
//                @await Component.InvokeAsync("SanPhamKhac")

//            </ div >

//        </ div >

//    </ div >
//</ div >
//< !--Single Product End --> *@