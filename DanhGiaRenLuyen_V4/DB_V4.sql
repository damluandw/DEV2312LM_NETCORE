USE [DanhGiaRenLuyen]
GO
CREATE TABLE Department(
Id INT IDENTITY   PRIMARY KEY,
Name NVARCHAR(50) ,
Times INT ,)


CREATE TABLE Course(
Id CHAR(4)  PRIMARY KEY,
Name NVARCHAR(50) ,)



CREATE TABLE Class(
Id INT IDENTITY   PRIMARY KEY,
Name CHAR(7) UNIQUE ,
CourseId CHAR(4) FOREIGN KEY (CourseId)REFERENCES Course(Id),
DepartmentId INT FOREIGN KEY (DepartmentId)REFERENCES  Department(Id),
IsActive TINYINT ,)


CREATE TABLE Position(
Id CHAR(3)  PRIMARY KEY,
Name NVARCHAR(20) ,)



CREATE TABLE Student(
Id CHAR(10)  PRIMARY KEY,
FullName NVARCHAR(50) ,
Birthday DATE ,
Email VARCHAR(50) ,
Phone VARCHAR(15) ,
Gender BIT ,
ClassId INT FOREIGN KEY (CLASSId)REFERENCES CLASS(Id),
PositionId CHAR(3) FOREIGN KEY (POSITIONId)REFERENCES POSITION(Id),
IsActive TINYINT ,)



CREATE TABLE Lecturer(
Id CHAR(10)  PRIMARY KEY,
FullName NVARCHAR(50) ,
DepartmentId INT FOREIGN KEY (DepartmentId)REFERENCES DEPARTMENT(Id),
PositionId CHAR(3) FOREIGN KEY (PositionId)REFERENCES POSITION(Id),
Birthday DATE ,
Email VARCHAR(50) ,
Phone VARCHAR(15) ,
IsActive TINYINT ,)




CREATE TABLE AccountStudent(
Id INT IDENTITY   PRIMARY KEY,
UserName VARCHAR(10) Unique,
Password VARCHAR(255) ,
CreateBy VARCHAR(20) ,
CreateDate DATETIME ,
UpdateDate DATETIME ,
IsActive TINYINT ,
StudentId CHAR(10) FOREIGN KEY (StudentId)REFERENCES STUDENT(Id),)


CREATE TABLE AccountLecturer(
Id INT IDENTITY   PRIMARY KEY,
UserName VARCHAR(10) Unique,
Password VARCHAR(255) ,
CreateBy VARCHAR(20) ,
CreateDate DATETIME ,
UpdateDate DATETIME ,
IsActive TINYINT ,
LecturerId CHAR(10) FOREIGN KEY (LecturerId)REFERENCES Lecturer(Id),)


CREATE TABLE Roles(
Id INT IDENTITY   PRIMARY KEY,
RoleName NVARCHAR(100) ,
IsActive TINYINT ,)



CREATE TABLE AccountAdmin(
Id INT IDENTITY   PRIMARY KEY,
FullName NVARCHAR(50) ,
UserName VARCHAR(20) Unique,
Password VARCHAR(255) ,
CreateBy VARCHAR(20) ,
CreateDate DATETIME ,
UpdateDate DATETIME ,
IsActive TINYINT ,
RoleId INT FOREIGN KEY (RoleId)REFERENCES ROLES(Id),)




CREATE TABLE Semester(
Id INT IDENTITY   PRIMARY KEY,
Name CHAR(2) ,
SchoolYear CHAR(20) ,
DateOpenStudent DATETIME ,
DateEndStudent DATETIME ,
DateEndClass DATETIME ,
DateEndLecturer DATETIME ,
IsActive TINYINT ,)


CREATE TABLE TypeQuestion(
Id INT IDENTITY   PRIMARY KEY,
Name NVARCHAR(100) ,)



CREATE TABLE GroupQuestion(
Id INT IDENTITY   PRIMARY KEY,
Name NVARCHAR(255) ,)



CREATE TABLE QuestionList(
Id INT IDENTITY   PRIMARY KEY,
ContentQuestion NVARCHAR(500) ,
TypeQuestionId INT FOREIGN KEY (TypeQuestionId)REFERENCES TYPEQUESTION(Id),
GroupQuestionId INT FOREIGN KEY (GroupQuestionId)REFERENCES GroupQuestion(Id),
OrderBy INT ,
Status TINYINT ,
IsEdit bit ,
CreateDate DATETIME ,
UpdateDate DATETIME ,
UpdateBy NVARCHAR(50) ,)




CREATE TABLE AnswerList(
Id INT IDENTITY   PRIMARY KEY,
QuestionId INT FOREIGN KEY (QuestionId)REFERENCES QuestionList(Id),
ContentAnswer NVARCHAR(500) ,
AnswerScore INT ,
Status TINYINT ,
IsEdit bit ,
CreateDate DATETIME ,
UpdateDate DATETIME ,
UpdateBy NVARCHAR(50) ,
Checked TINYINT ,)


CREATE TABLE QuestionHisory(
Id INT IDENTITY   PRIMARY KEY,
QuestionId INT FOREIGN KEY (QuestionId)REFERENCES QuestionList(Id),
SemesterId INT FOREIGN KEY (SemesterId)REFERENCES SEMESTER(Id),
OrderBy INT ,
CreateBy CHAR(10) ,
CreateDate DATETIME ,)




CREATE TABLE SelfAnswer(
Id INT IDENTITY   PRIMARY KEY,
StudentId CHAR(10) FOREIGN KEY (StudentId)REFERENCES STUDENT(Id),
AnswerId INT FOREIGN KEY (AnswerId)REFERENCES ANSWERLIST(Id),
SemesterId INT FOREIGN KEY (SemesterId)REFERENCES Semester(Id),)



CREATE TABLE ClassAnswer(
Id INT IDENTITY   PRIMARY KEY,
StudentId CHAR(10) FOREIGN KEY (StudentId)REFERENCES STUDENT(Id),
AnswerId INT FOREIGN KEY (AnswerId)REFERENCES ANSWERLIST(Id),
CreateBy CHAR(10) ,
CreateDate DATETIME ,)



CREATE TABLE SumaryOfPoint(
Id INT IDENTITY   PRIMARY KEY,
StudentId CHAR(10) FOREIGN KEY (StudentId)REFERENCES STUDENT(Id),
SemesterId INT FOREIGN KEY (SemesterId)REFERENCES Semester(Id),
ClassId INT FOREIGN KEY (CLASSId)REFERENCES CLASS(Id),
SelfPoint INT ,
ClassPoint INT ,
LecturerPoint INT ,
Classify NVARCHAR(50) ,
UserClass CHAR(10) ,
UserLecturer CHAR(10) ,
UpdateDate DATETIME ,)




CREATE TABLE Classify(
Id INT IDENTITY   PRIMARY KEY,
Name NVARCHAR(50) ,
PointMin INT ,
PointMax INT ,
OrderBy INT ,)




GO

INSERT INTO  DEPARTMENT VALUES (N'Công nghệ thông tin', 4)
INSERT INTO  COURSE VALUES
('K21', '2021-2025'),
('K22', '2022-2026'),
('K23', '2023-2027')
INSERT INTO  CLASS VALUES
('K21CNT1','K21',1,0),
('K21CNT2','K21',1,0),
('K22CNT1','K22',1,0),
('K22CNT2','K22',1,0),
('K22CNT3','K22',1,0),
('K22CNT4','K22',1,0),
('K23CNT1','K23',1,0),
('K23CNT2','K23',1,0),
('K23CNT3','K23',1,0),
('K23CNT4','K23',1,0)
INSERT INTO  POSITION VALUES
('SV', N'Sinh viên'),
('LT',N'Lớp trưởng'),
('GV',N'Giảng viên')
INSERT INTO  LECTURER VALUES
('GV00000001',N'Đàm Luận',1,'GV','19970917','luan.dv@ntu-hn.edu.vn','0976897563',1)
INSERT INTO  [dbo].[Roles] VALUES
('admin',1)
INSERT INTO  [dbo].[ACCOUNTADMIN] ([USERNAME],[PASSWORD],ISACTIVE,ROLEID) VALUES
('admin','12345',1,1)
INSERT INTO  AccountLecturer(USERNAME,PASSWORD,LecturerID) VALUES
('GV00000001',N'12345','GV00000001')
INSERT INTO  STUDENT VALUES
('2110900054',N'Nguyễn Ngọc Việt','20030813','','',0,1,'LT',1),
('2110900009',N'Đặng Trần Đức','20030802','','',0,1,'SV',1),
('2110900025',N'Lê Đình Hùng','20030209','','',0,1,'SV',1),
('2110900052',N'Nguyễn Mạnh Hùng','20030807','','',0,1,'SV',1),
('2110900037',N'Nguyễn Tuấn Tài','20030711','','',0,1,'SV',1)
INSERT INTO  AccountStudent (USERNAME,PASSWORD,STUDENTID) VALUES
('2110900054',N'12345','2110900054'),
('2110900009',N'12345','2110900009'),
('2110900025',N'12345','2110900025'),
('2110900052',N'12345','2110900052'),
('2110900037',N'12345','2110900037')
INSERT INTO  TypeQuestion VALUES
(N'Câu hỏi chọn 1'),
(N'Câu hỏi nhiều lựa chọn (điểm khác nhau)'),
(N'Câu hỏi có nhiều lựa chọn(chung điểm)')

INSERT INTO  Semester VALUES
(1,N'2023-2024','20240301','20240401','20240415','20240501',1)

INSERT INTO  GroupQuestion VALUES
(N'ĐÁNH GIÁ VỀ Ý THỨC THAM GIA HỌC TẬP VÀ NGHIÊN CỨU KHOA HỌC'),
(N'ĐÁNH GIÁ VỀ Ý THỨC CHẤP HÀNH CÁC NỘI QUY, QUY CHẾ, QUY ĐỊNH TRONG NHÀ TRƯỜNG'),
(N'HÀNH ĐỘNG HƯỚNG ĐẾN XÂY DỰNG VÀ PHÁT TRIỂN CỘNG ĐỒNG'),
(N'CÁC NỘI DUNG KHUYẾN KHÍCH CỘNG THÊM')

INSERT INTO  QuestionList VALUES
(N'Vi phạm Quy chế học vụ, Quy định khảo thí',1,1,1,1,1,'20240428',NULL,'admin'),
(N'Điểm trung bình chung học tập tính đến hết học kỳ 1, năm học 2023 - 2024 của bạn là: (Điểm hệ số 4)',1,1,2,1,1,'20240428',NULL,'admin'),
(N'Giữ xếp loại xuất sắc so với học kỳ trước',1,1,3,1,1,'20240428',NULL,'admin'),
(N'Tăng điểm trung bình tích lũy so với học kỳ trước đó',1,1,4,1,1,'20240428',NULL,'admin'),
(N'Tham gia NCKH và các hoạt động học thuật ngoại khóa (5 điểm)',3,1,5,1,1,'20240428',NULL,'admin'),
(N'Vi phạm nội quy, quy chế, quy định của Nhà trường',1,2,6,1,1,'20240428',NULL,'admin'),
(N'Tham gia đánh giá trên 50% số môn học trong kỳ',1,2,7,1,1,'20240428',NULL,'admin'),
(N'Không có hành vi vi phạm hoặc che giấu các tệ nạn xã hội ',1,2,8,1,1,'20240428',NULL,'admin'),
(N'Tham gia các các hoạt động chính trị - xã hội, văn hóa - văn nghệ, thể dục - thể thao',2,2,9,1,1,'20240428',NULL,'admin'),
(N'Tham gia xây dựng, đóng góp, quảng bá hình ảnh của Trường',2,2,10,1,1,'20240428',NULL,'admin'),
(N'Chấp hành pháp luật và các văn bản quy phạm pháp luật',1,3,11,1,1,'20240428',NULL,'admin'),
(N'Tham gia các hoạt động tình nguyện, hành động giải quyết vấn đề xã hội, các hoạt động chung của lớp, Khoa và Nhà trường (10 đ)',3,3,12,1,1,'20240428',NULL,'admin'),
(N'Tham gia tuyên truyền các chủ trương của Đảng, chính sách, pháp luật của Nhà nước trong cộng đồng',3,3,13,1,1,'20240428',NULL,'admin'),
(N'Thành tích xuất sắc trong các kỳ thi, cuộc thi, học tập và rèn luyện (10 điểm)',3,4,14,1,1,'20240428',NULL,'admin'),
(N'Nhận được học bổng do các tổ chức có tư các	h pháp nhân trao tặng vì tinh thần vượt khó, phấn đấu vươn lên trong học tập và cuộc sống',1,4,15,1,1,'20240428',NULL,'admin'),
(N'Các trường hợp có hoàn cảnh đặc biệt (10 điểm)',3,4,16,1,1,'20240428',NULL,'admin')

INSERT INTO  AnswerList VALUES
(1,N'Có (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(1,N'Không (10 điểm)',10,1,1,'20240428',NULL,'admin',NULL),
(2,N'Từ 0.0 đến dưới 2.0 (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(2,N'Từ 2.0 đến dưới 2.5 (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(2,N'Từ 2.5 đến dưới 3.2 (3 điểm)',3,1,1,'20240428',NULL,'admin',NULL),
(2,N'Từ 3.2 đến dưới 3.6 (6 điểm)',6,1,1,'20240428',NULL,'admin',NULL),
(2,N'Trên 3.6 (9 điểm)',9,1,1,'20240428',NULL,'admin',NULL),
(3,N'Có (2 điểm)',2,1,1,'20240428',NULL,'admin',NULL),
(3,N'Không (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(4,N'Từ 0.1 đến dưới 0.2 (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(4,N'Từ 0.2 đến dưới 0.4 (1 điểm)',1,1,1,'20240428',NULL,'admin',NULL),
(4,N'Từ 0.4 đến dưới 0.6 (2 điểm)',2,1,1,'20240428',NULL,'admin',NULL),
(4,N'Từ 0.6 đến dưới 0.8 (3 điểm)',3,1,1,'20240428',NULL,'admin',NULL),
(4,N'Từ 0.8 trở lên (4 điểm)',4,1,1,'20240428',NULL,'admin',NULL),
(5,N'Là tác giả của đề tài nghiên cứu khoa học từ cấp Khoa trở lên',5,1,1,'20240428',NULL,'admin',NULL),
(5,N'Tham gia cuộc thi học thuật từ cấp Khoa trở lên',5,1,1,'20240428',NULL,'admin',NULL),
(5,N'Là thành viên trong Ban tổ chức/Cộng tác viên của một cuộc thi học thuật từ cấp Khoa trở lên',5,1,1,'20240428',NULL,'admin',NULL),
(5,N'Sinh viên tham gia sinh hoạt thường xuyên tại các câu lạc bộ học thuật, các phòng thí nghiệm, thư viện',5,1,1,'20240428',NULL,'admin',NULL),
(5,N'Tham gia hoặc tổ chức các buổi sinh hoạt, hội thảo chuyên đề học thuật, kỹ năng, nghiên cứu khoa học, tư vấn hướng nghiệp',5,1,1,'20240428',NULL,'admin',NULL),
(5,N'Không tham gia hoạt động nào (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(6,N'Có (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(6,N'Không (15 điểm)',15,1,1,'20240428',NULL,'admin',NULL),
(7,N'Có (5 điểm)',5,1,1,'20240428',NULL,'admin',NULL),
(7,N'Không (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(8,N'Không (5 điểm)',5,1,1,'20240428',NULL,'admin',NULL),
(8,N'Có (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(9,N'Tham gia cuộc thi về khoa học chính trị, khoa học Mác-Lênin, tư tưởng Hồ Chí Minh, lịch sử, văn hóa. (1 điểm)',1,1,1,'20240428',NULL,'admin',NULL),
(9,N'Nhận được giấy chứng nhận danh hiệu về sức khỏe thể chất trong các ngày hội thể dục - thể thao. (2 điểm)',2,1,1,'20240428',NULL,'admin',NULL),
(9,N'Tham gia các đợt huy động lực lượng cấp Trường, cấp Khoa. (2 điểm)',2,1,1,'20240428',NULL,'admin',NULL),
(9,N'Là thành viên tích cực và sinh hoạt thường xuyên của một Câu lạc bộ cấp Khoa trở lên. (2 đ)',2,1,1,'20240428',NULL,'admin',NULL),
(9,N'Tham gia các hoạt động cấp lớp. (1 điểm)',1,1,1,'20240428',NULL,'admin',NULL),
(9,N'Là thành viên đội tuyển cấp Trường hoặc cấp cao hơn của một cuộc thi/chương trình bất kỳ có quy mô tham dự từ 4 đội tuyển trở lên. (2 điểm)',2,1,1,'20240428',NULL,'admin',NULL),
(9,N'Không tham gia hoạt động nào (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(10,N'Tham gia các đợt hoạt động tư vấn tuyển sinh, hội thảo việc làm từ cấp Khoa trở lên (2 điểm)',2,1,1,'20240428',NULL,'admin',NULL),
(10,N'Tham gia các cuộc thi, chương trình tìm hiểu về lịch sử phát triển Nhà trường, các tổ chức đoàn thể trong Nhà trường (2 điểm)',2,1,1,'20240428',NULL,'admin',NULL),
(10,N'Tham gia đóng góp cho các đợt lấy ý kiến về văn bản quy phạm pháp luật các cấp, các văn bản nội bộ, các chương trình đối thoại với lãnh đạo nhằm xây dựng, phát triển Nhà trường (1 điểm)',1,1,1,'20240428',NULL,'admin',NULL),
(10,N'Là tác giả, đồng tác giả của sản phẩm/dự án truyền thông nhằm giới thiệu, quảng bá hình ảnh về Trường (1 điểm)',1,1,1,'20240428',NULL,'admin',NULL),
(10,N'Được nhà trường tuyển chọn hoặc tự ứng tuyển là đại biểu chính thức tham gia chương trình giao lưu, trao đổi văn hóa, học thuật trong khu vực và quốc tế (2 điểm)',2,1,1,'20240428',NULL,'admin',NULL),
(10,N'Là thành viên trong Ban tổ chức/Cộng tác viên của các hoạt động từ cấp Khoa trở lên (2 điểm)',2,1,1,'20240428',NULL,'admin',NULL),
(10,N'Không tham gia hoạt động nào (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(11,N'Có vi phạm pháp luật (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(11,N'Không vi phạm pháp luật (10 điểm)',10,1,1,'20240428',NULL,'admin',NULL),
(12,N'Tham gia hiến máu tình nguyện (Có giấy chứng nhận)',10,1,1,'20240428',NULL,'admin',NULL),
(12,N'Là tình nguyện viên của các hoạt động, chương trình tình nguyện vì cộng đồng',10,1,1,'20240428',NULL,'admin',NULL),
(12,N'Là thành viên Ban tổ chức của các hoạt động tình nguyện',10,1,1,'20240428',NULL,'admin',NULL),
(12,N'Tham gia các hoạt động quyên góp do các tổ chức, đơn vị trong Nhà trường phát động',10,1,1,'20240428',NULL,'admin',NULL),
(12,N'Không tham gia hoạt động nào (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(13,N'Tham gia các cuộc thi, chương trình tuyên truyền về Hiến pháp và các văn bản luật, đẩy lùi tệ nạn, phòng chống dịch bệnh các cấp hoặc do chính quyền, đoàn thể nơi cư trú phát động và tổ chức.',5,1,1,'20240428',NULL,'admin',NULL),
(13,N'Được đánh giá hoàn thành tốt nhiệm vụ trở lên đối với vai trò là thành viên Ban cán sự lớp trong năm học',5,1,1,'20240428',NULL,'admin',NULL),
(13,N'Được đánh giá phân loại một trong hai danh hiệu sau: Đoàn viên hoàn thành xuất sắc nhiệm vụ; Đảng viên hoàn thành tốt nhiệm vụ',5,1,1,'20240428',NULL,'admin',NULL),
(13,N'Không tham gia hoạt động nào (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(14,N'Có thành tích đặc biệt trong học tập, rèn luyện và nhận được các hình thức khen thưởng',10,1,1,'20240428',NULL,'admin',NULL),
(14,N'Đạt một trong các giải thưởng trong các cuộc thi, sân chơi từ cấp Khoa trở lên',10,1,1,'20240428',NULL,'admin',NULL),
(14,N'Là thành viên đội tuyển tham dự kỳ thi Olympic/kỳ thi học thuật cấp thành phố trở lên',10,1,1,'20240428',NULL,'admin',NULL),
(14,N'Là tác giả/đồng tác giả của bài báo khoa học được đăng trên tạp chí trong nước hoặc quốc tế uy tín',10,1,1,'20240428',NULL,'admin',NULL),
(14,N'Đạt giải thưởng do các tổ chức chính phủ, phi chính phủ, tổ chức đa quốc gia trao tặng',10,1,1,'20240428',NULL,'admin',NULL),
(14,N'Không có thành tích nào (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(15,N'Có (10 điểm)',10,1,1,'20240428',NULL,'admin',NULL),
(15,N'Không (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL),
(16,N'Mồ côi cả cha lẫn mẹ',10,1,1,'20240428',NULL,'admin',NULL),
(16,N'Sinh viên khuyết tật, khó khăn trong đi lại và sinh hoạt',10,1,1,'20240428',NULL,'admin',NULL),
(16,N'Hộ nghèo, Hộ cận nghèo được hưởng chính sách theo quy định của Bộ Giáo dục & Đào tạo',10,1,1,'20240428',NULL,'admin',NULL),
(16,N'Không thuộc diện nào (0 điểm)',0,1,1,'20240428',NULL,'admin',NULL)

INSERT INTO [dbo].[QuestionHisory] 
SELECT ID,1,OrderBy,'admin','20240428' FROM QuestionList