INSERT INTO [DocTypes] ([ID], [DocTypeGroupID], [Name], [Code], [Comment], [TempFile], [Active], [Count], [Color], [IsHistory], [IsAllowDownloadOtherFile]) VALUES (1002, 2, N'نقشه دو بعدی', N'2D', NULL, NULL, '1', 4, N'#93abb8', '0', '0');
GO
INSERT INTO [DocTypes] ([ID], [DocTypeGroupID], [Name], [Code], [Comment], [TempFile], [Active], [Count], [Color], [IsHistory], [IsAllowDownloadOtherFile]) VALUES (1003, 2, N'مدل 3 بعدی', N'3D', NULL, NULL, '1', 2, N'#575d8c', '0', '0');
GO
INSERT INTO [DocTypes] ([ID], [DocTypeGroupID], [Name], [Code], [Comment], [TempFile], [Active], [Count], [Color], [IsHistory], [IsAllowDownloadOtherFile]) VALUES (1004, 2, N'پیوست فنی', N'SP', NULL, NULL, '1', 2, N'#27c6e6', '0', '0');
GO
INSERT INTO [DocTypes] ([ID], [DocTypeGroupID], [Name], [Code], [Comment], [TempFile], [Active], [Count], [Color], [IsHistory], [IsAllowDownloadOtherFile]) VALUES (1005, 1002, N'فرم کنترلی', N'CF', NULL, NULL, '1', 1, N'#bd76de', '0', '0');
GO
INSERT INTO [DocTypes] ([ID], [DocTypeGroupID], [Name], [Code], [Comment], [TempFile], [Active], [Count], [Color], [IsHistory], [IsAllowDownloadOtherFile]) VALUES (1006, 1003, N'قرارداد', N'PC', NULL, NULL, '1', 0, N'#82bee0', '0', '0');
GO
INSERT INTO [DocTypes] ([ID], [DocTypeGroupID], [Name], [Code], [Comment], [TempFile], [Active], [Count], [Color], [IsHistory], [IsAllowDownloadOtherFile]) VALUES (1007, 1003, N'مستندات دریافتی از کارفرما', N'CD', NULL, NULL, '1', 0, N'#eb3b79', '0', '0');
GO
INSERT INTO [Documents] ([ID], [DocName], [DocCode], [ProjectName], [ProjectCode], [DocAbstract], [DocKey], [DocPageNum], [AccessSecurityLevelID], [DocDate], [AuthorName], [OthersAuthor], [TechSurveyorNameText], [SysSurveyorNameText], [ConfirmerNameText], [ApproverNameText], [InsertType], [DocEditFile], [DocPdfFile], [DocOtherFile], [DOCTYPEID], [DocSection], [DocScope], [DocOld], [DocComment], [ApplicationNumber], [IsValid], [LinkToTreePlace], [ProjectId], [Description]) VALUES (15, N'پیوست فنی Skt head cap screw', N'BC-RE-SP-002-00', N'B-C-PUMP', '', '', '', '', 1, N'۱۴۰۲/۱۲/۱۷', N'madad_admin', '', '', '', '', '', N'PM_Direct', NULL, NULL, NULL, 1004, NULL, NULL, NULL, NULL, N'49', '1', N'3', N'1', NULL);
GO
INSERT INTO [Documents] ([ID], [DocName], [DocCode], [ProjectName], [ProjectCode], [DocAbstract], [DocKey], [DocPageNum], [AccessSecurityLevelID], [DocDate], [AuthorName], [OthersAuthor], [TechSurveyorNameText], [SysSurveyorNameText], [ConfirmerNameText], [ApproverNameText], [InsertType], [DocEditFile], [DocPdfFile], [DocOtherFile], [DOCTYPEID], [DocSection], [DocScope], [DocOld], [DocComment], [ApplicationNumber], [IsValid], [LinkToTreePlace], [ProjectId], [Description]) VALUES (16, N'فرم کنترلی Skt head cap screw', N'BC-RE-CF-001-00', N'B-C-PUMP', '', '', '', '', 1, N'۱۴۰۲/۱۲/۱۷', N'madad_admin', '', '', '', '', '', N'PM_Direct', NULL, NULL, NULL, 1005, NULL, NULL, NULL, NULL, N'49', '1', N'3', N'1', NULL);
GO
INSERT INTO [Documents] ([ID], [DocName], [DocCode], [ProjectName], [ProjectCode], [DocAbstract], [DocKey], [DocPageNum], [AccessSecurityLevelID], [DocDate], [AuthorName], [OthersAuthor], [TechSurveyorNameText], [SysSurveyorNameText], [ConfirmerNameText], [ApproverNameText], [InsertType], [DocEditFile], [DocPdfFile], [DocOtherFile], [DOCTYPEID], [DocSection], [DocScope], [DocOld], [DocComment], [ApplicationNumber], [IsValid], [LinkToTreePlace], [ProjectId], [Description]) VALUES (17, N'مدل 3 بعدی Skt head cap screw', N'BC-RE-3D-001-00', N'B-C-PUMP', '', '', '', '', 1, N'۱۴۰۲/۱۲/۱۷', N'madad_admin', '', '', '', '', '', N'PM_Direct', NULL, NULL, NULL, 1003, NULL, NULL, NULL, NULL, N'52', '1', N'3', N'1', NULL);
GO
INSERT INTO [Documents] ([ID], [DocName], [DocCode], [ProjectName], [ProjectCode], [DocAbstract], [DocKey], [DocPageNum], [AccessSecurityLevelID], [DocDate], [AuthorName], [OthersAuthor], [TechSurveyorNameText], [SysSurveyorNameText], [ConfirmerNameText], [ApproverNameText], [InsertType], [DocEditFile], [DocPdfFile], [DocOtherFile], [DOCTYPEID], [DocSection], [DocScope], [DocOld], [DocComment], [ApplicationNumber], [IsValid], [LinkToTreePlace], [ProjectId], [Description]) VALUES (18, N'نقشه دو بعدی Pump case wear ring', N'BC-RE-2D-001-00', N'B-C-PUMP', '', '', '', '', 1, N'۱۴۰۳/۰۱/۰۶', N'4420681039', '', '', '', '', '', N'PM_Direct', NULL, NULL, NULL, 1002, NULL, NULL, NULL, NULL, N'66', '1', N'5', N'1', NULL);
GO
INSERT INTO [Documents] ([ID], [DocName], [DocCode], [ProjectName], [ProjectCode], [DocAbstract], [DocKey], [DocPageNum], [AccessSecurityLevelID], [DocDate], [AuthorName], [OthersAuthor], [TechSurveyorNameText], [SysSurveyorNameText], [ConfirmerNameText], [ApproverNameText], [InsertType], [DocEditFile], [DocPdfFile], [DocOtherFile], [DOCTYPEID], [DocSection], [DocScope], [DocOld], [DocComment], [ApplicationNumber], [IsValid], [LinkToTreePlace], [ProjectId], [Description]) VALUES (19, N'پیوست فنی Impeller nut', N'BC-RE-SP-001-00', N'BCP - BISOTON', '', '', '', '', 1, N'۱۴۰۳/۰۲/۰۹', N'4420681039', '', '', '', '', '', N'PM_Direct', NULL, NULL, NULL, 1004, NULL, NULL, NULL, NULL, N'81', '1', N'4', N'1', NULL);
GO
INSERT INTO [Documents] ([ID], [DocName], [DocCode], [ProjectName], [ProjectCode], [DocAbstract], [DocKey], [DocPageNum], [AccessSecurityLevelID], [DocDate], [AuthorName], [OthersAuthor], [TechSurveyorNameText], [SysSurveyorNameText], [ConfirmerNameText], [ApproverNameText], [InsertType], [DocEditFile], [DocPdfFile], [DocOtherFile], [DOCTYPEID], [DocSection], [DocScope], [DocOld], [DocComment], [ApplicationNumber], [IsValid], [LinkToTreePlace], [ProjectId], [Description]) VALUES (20, N'نقشه دو بعدی Pump case wear ring', N'BC-RE-2D-003-00', N'BCP - BISOTON', '', '', '', '', 1, N'۱۴۰۳/۰۱/۲۸', N'4420681039', '', '', '', '', '', N'PM_Direct', NULL, NULL, NULL, 1002, NULL, NULL, NULL, NULL, N'75', '1', N'5', N'1', NULL);
GO
INSERT INTO [Documents] ([ID], [DocName], [DocCode], [ProjectName], [ProjectCode], [DocAbstract], [DocKey], [DocPageNum], [AccessSecurityLevelID], [DocDate], [AuthorName], [OthersAuthor], [TechSurveyorNameText], [SysSurveyorNameText], [ConfirmerNameText], [ApproverNameText], [InsertType], [DocEditFile], [DocPdfFile], [DocOtherFile], [DOCTYPEID], [DocSection], [DocScope], [DocOld], [DocComment], [ApplicationNumber], [IsValid], [LinkToTreePlace], [ProjectId], [Description]) VALUES (21, N'نقشه دو بعدی Impeller nut', N'BC-RE-2D-002-00', N'BCP - BISOTON', '', '', '', '', 1, N'۱۴۰۳/۰۱/۲۸', N'4420681039', '', '', '', '', '', N'PM_Direct', NULL, NULL, NULL, 1002, NULL, NULL, NULL, NULL, N'71', '1', N'4', N'1', NULL);
GO
INSERT INTO [Documents] ([ID], [DocName], [DocCode], [ProjectName], [ProjectCode], [DocAbstract], [DocKey], [DocPageNum], [AccessSecurityLevelID], [DocDate], [AuthorName], [OthersAuthor], [TechSurveyorNameText], [SysSurveyorNameText], [ConfirmerNameText], [ApproverNameText], [InsertType], [DocEditFile], [DocPdfFile], [DocOtherFile], [DOCTYPEID], [DocSection], [DocScope], [DocOld], [DocComment], [ApplicationNumber], [IsValid], [LinkToTreePlace], [ProjectId], [Description]) VALUES (22, N'نقشه دو بعدی Tab washer قابل اصلاح', N'BC-RE-2D-004-00', N'BCP - BISOTON', '', '', '', '', 1, N'۱۴۰۳/۰۲/۱۳', N'madad_admin', '', '', '', '', '', N'PM_Direct', NULL, NULL, NULL, 1002, NULL, NULL, NULL, NULL, N'93', '1', N'29', N'1', NULL);
GO
INSERT INTO [Documents] ([ID], [DocName], [DocCode], [ProjectName], [ProjectCode], [DocAbstract], [DocKey], [DocPageNum], [AccessSecurityLevelID], [DocDate], [AuthorName], [OthersAuthor], [TechSurveyorNameText], [SysSurveyorNameText], [ConfirmerNameText], [ApproverNameText], [InsertType], [DocEditFile], [DocPdfFile], [DocOtherFile], [DOCTYPEID], [DocSection], [DocScope], [DocOld], [DocComment], [ApplicationNumber], [IsValid], [LinkToTreePlace], [ProjectId], [Description]) VALUES (23, N'مدل 3 بعدی Tab washer', N'BC-RE-3D-002-00', N'BCP - BISOTON', '', '', '', '', 1, N'۱۴۰۳/۰۲/۱۳', N'madad_admin', '', '', '', '', '', N'PM_Direct', NULL, NULL, NULL, 1003, NULL, NULL, NULL, NULL, N'93', '1', N'29', N'1', NULL);
GO
INSERT INTO [layer] ([layerName], [intLayerTypeID], [sectionTypeID], [layerLevel]) VALUES ('product', 1, '1006', 1);
GO
INSERT INTO [layer] ([layerName], [intLayerTypeID], [sectionTypeID], [layerLevel]) VALUES ('Config', 2, '1007', 2);
GO
INSERT INTO [layer] ([layerName], [intLayerTypeID], [sectionTypeID], [layerLevel]) VALUES ('standard', 3, '1002', 3);
GO
INSERT INTO [SectionTypes] ([ID], [TypeName], [Color]) VALUES (1002, N'استاندارد', N'#74ab54');
GO
INSERT INTO [SectionTypes] ([ID], [TypeName], [Color]) VALUES (1003, N'خرید خارج', N'#1798a6');
GO
INSERT INTO [SectionTypes] ([ID], [TypeName], [Color]) VALUES (1004, N'ساخت - بدون تامین مواد', N'#d094f2');
GO
INSERT INTO [SectionTypes] ([ID], [TypeName], [Color]) VALUES (1005, N'ساخت - با تامین مواد', N'#a539cc');
GO
INSERT INTO [SectionTypes] ([ID], [TypeName], [Color]) VALUES (1006, N'محصول', N'#6dd6c1');
GO
INSERT INTO [SectionTypes] ([ID], [TypeName], [Color]) VALUES (1007, N'آیتتم پیکره بندی', N'#693939');
GO
INSERT INTO [SectionTypeTreeSectionCharts] ([SectionType_ID], [TreeSectionChart_ID]) VALUES (1006, 3090);
GO
INSERT INTO [SectionTypeTreeSectionCharts] ([SectionType_ID], [TreeSectionChart_ID]) VALUES (1007, 3091);
GO
INSERT INTO [SectionTypeTreeSectionCharts] ([SectionType_ID], [TreeSectionChart_ID]) VALUES (1007, 3092);
GO
INSERT INTO [SectionTypeTreeSectionCharts] ([SectionType_ID], [TreeSectionChart_ID]) VALUES (1002, 3093);
GO
INSERT INTO [SectionTypeTreeSectionCharts] ([SectionType_ID], [TreeSectionChart_ID]) VALUES (1002, 3094);
GO
INSERT INTO [SectionTypeTreeSectionCharts] ([SectionType_ID], [TreeSectionChart_ID]) VALUES (1002, 3095);
GO
INSERT INTO [SectionTypeTreeSectionCharts] ([SectionType_ID], [TreeSectionChart_ID]) VALUES (1002, 3096);
GO
INSERT INTO [SectionTypeTreeSectionCharts] ([SectionType_ID], [TreeSectionChart_ID]) VALUES (1002, 3097);
GO
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (1, 'feasibility', 1, '1002,20;1003,30;1004,50');
GO
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (2, 'consept design', 2, '1002,90;1003,10');
GO
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (3, 'requirement', 2, NULL);
GO
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (4, 'items', 3, NULL);
GO
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (5, 'new station 1', 2, NULL);
GO
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (6, 'new station 2', 3, NULL);
GO
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (7, 'new station 3', 1, NULL);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (3090, 15);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (3090, 16);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (3, 17);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (3090, 17);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (5, 18);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (3090, 18);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (4, 19);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (5, 20);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (4, 21);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (29, 22);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (3091, 22);
GO
INSERT INTO [TreeSectionChartDocuments] ([TreeSectionChart_ID], [Document_ID]) VALUES (29, 23);
GO
INSERT INTO [TreeSectionCharts] ([ID], [SectionName], [ParentID]) VALUES (3090, N'محصول', NULL);
GO
INSERT INTO [TreeSectionCharts] ([ID], [SectionName], [ParentID]) VALUES (3091, N'آیتم پیکره بندی اول', 3090);
GO
INSERT INTO [TreeSectionCharts] ([ID], [SectionName], [ParentID]) VALUES (3092, N'آیتم پیکره بندی دوم', 3090);
GO
INSERT INTO [TreeSectionCharts] ([ID], [SectionName], [ParentID]) VALUES (3093, N'قطعه اول', 3091);
GO
INSERT INTO [TreeSectionCharts] ([ID], [SectionName], [ParentID]) VALUES (3094, N'قطعه دوم', 3091);
GO
INSERT INTO [TreeSectionCharts] ([ID], [SectionName], [ParentID]) VALUES (3095, N'قطعه سوم', 3091);
GO
INSERT INTO [TreeSectionCharts] ([ID], [SectionName], [ParentID]) VALUES (3096, N'قطعه چهارم', 3092);
GO
INSERT INTO [TreeSectionCharts] ([ID], [SectionName], [ParentID]) VALUES (3097, N'قطعه پنجم', 3092);
GO
