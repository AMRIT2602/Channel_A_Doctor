SET IDENTITY_INSERT [dbo].[Patient] ON
INSERT INTO [dbo].[Patient] ([Id], [Name], [IDNumber], [Phone]) VALUES (1, N'Frank Winston', N'LA001845', N'02109812349')
INSERT INTO [dbo].[Patient] ([Id], [Name], [IDNumber], [Phone]) VALUES (2, N'George Samson', N'LA001955', N'02189623456')
SET IDENTITY_INSERT [dbo].[Patient] OFF
SET IDENTITY_INSERT [dbo].[MedicalCentre] ON
INSERT INTO [dbo].[MedicalCentre] ([Id], [Name], [Phone]) VALUES (1, N'City Medical', N'02198765439')
INSERT INTO [dbo].[MedicalCentre] ([Id], [Name], [Phone]) VALUES (2, N'Health Line Medical', N'02156789023')
INSERT INTO [dbo].[MedicalCentre] ([Id], [Name], [Phone]) VALUES (3, N'Auckland Doctors', N'02198765439')
SET IDENTITY_INSERT [dbo].[MedicalCentre] OFF
SET IDENTITY_INSERT [dbo].[Doctor] ON
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (1, N'Dr David Holmes', CAST(100.00 AS Decimal(18, 2)), 2)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (2, N'Dr Ray Davidson', CAST(150.00 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (3, N'Dr Harry Watson', CAST(200.00 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[Doctor] ([Id], [Name], [Charge], [MedicalCentreId]) VALUES (4, N'Dr Dave Jackson', CAST(150.00 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[Doctor] OFF
SET IDENTITY_INSERT [dbo].[Appointment] ON
INSERT INTO [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppointmentDate]) VALUES (1, 1, 1, N'2019-10-25 09:45:00')
INSERT INTO [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppointmentDate]) VALUES (2, 3, 1, N'2019-10-31 09:25:00')
INSERT INTO [dbo].[Appointment] ([Id], [DoctorId], [PatientId], [AppointmentDate]) VALUES (3, 1, 2, N'2019-10-26 19:45:00')
SET IDENTITY_INSERT [dbo].[Appointment] OFF
