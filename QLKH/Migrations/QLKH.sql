create database QLKH;
use QLKH;

create table Khachhang(
	makhachhang varchar(20) primary key,
	tenkhachhang nvarchar(50) not null,
	sodienthoai varchar(15)
);

create table Hoadon(
	mahoadon varchar(20) primary key,
	ngaytao datetime not null,
	makhachhang varchar(20)
	CONSTRAINT fk_hd_id_khachhang 
	FOREIGN KEY (makhachhang)
	REFERENCES Khachhang (makhachhang)
);

create table phieuxuat(
	maphieuxuat varchar(20) primary key,
	ngaytao datetime not null,
	makhachhang varchar(20) not null
	CONSTRAINT fk_px_id_khachhang 
	FOREIGN KEY (makhachhang)
	REFERENCES Khachhang (makhachhang)
)

create table nhacc(
	mancc varchar(20) primary key,
	tenncc varchar(25) not null,
	sdt varchar(15)
);

create table phieunhap(
	maphieunhap varchar(20) primary key,
	ngaytao datetime not null,
	mancc varchar(20) not null
	CONSTRAINT fk_pn_id_ncc 
	FOREIGN KEY (mancc)
	REFERENCES nhacc (mancc)
);

create table nhapxuatton(
	mahanghoa varchar(20) not null,
	nhap int not null,
	xuat int not null,
	ton int not null
);

create table hanghoa(
	mahanghoa varchar(20) primary key,
	tenhanghoa varchar(25) not null,
	dongia decimal(18,0) not null,
	donvitinh nvarchar(15) not null,
	mancc varchar(20) not null
	CONSTRAINT fk_hh_id_ncc 
	FOREIGN KEY (mancc)
	REFERENCES nhacc (mancc)
);

alter table nhapxuatton 
add CONSTRAINT fk_nxt 
foreign key (mahanghoa)
REFERENCES hanghoa (mahanghoa);

create table chitietxuat(
	stt int IDENTITY(1,1) primary key,
	maphieuxuat varchar(20) not null
	CONSTRAINT fk_ctx_id_px 
	FOREIGN KEY (maphieuxuat)
	REFERENCES phieuxuat (maphieuxuat),
	mahanghoa varchar(20) not null
	CONSTRAINT fk_ctx_id_hh 
	FOREIGN KEY (mahanghoa)
	REFERENCES hanghoa (mahanghoa),
	soluong int not null,
	ngayxuat datetime,
	makhachhang varchar(20) not null
	CONSTRAINT fk_ctx_id_kh 
	FOREIGN KEY (makhachhang)
	REFERENCES Khachhang (makhachhang)
);

create table chitietnhap(
	stt int IDENTITY(1,1) primary key,
	maphieunhap varchar(20) not null
	CONSTRAINT fk_ctn_id_pn 
	FOREIGN KEY (maphieunhap)
	REFERENCES phieunhap (maphieunhap),
	mahanghoa varchar(20) not null
	CONSTRAINT fk_ctn_id_hh 
	FOREIGN KEY (mahanghoa)
	REFERENCES hanghoa (mahanghoa),
	soluong int not null,
	ngayxuat datetime,
	makhachhang varchar(20) not null
	CONSTRAINT fk_ctn_id_kh 
	FOREIGN KEY (makhachhang)
	REFERENCES Khachhang (makhachhang)
);

create table taikhoan(
	id int IDENTITY(1,1) primary key,
	username varchar(30) not null,
	matkhau varchar(30) not null,
	fullcontrol BIT DEFAULT 0
);








