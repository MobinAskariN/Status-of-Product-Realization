INSERT INTO [layer] ([layerName], [intLayerTypeID], [sectionTypeID], [layerLevel]) VALUES ('product', 1, '1006', 1);
GO
INSERT INTO [layer] ([layerName], [intLayerTypeID], [sectionTypeID], [layerLevel]) VALUES ('Config', 2, '1007', 2);
GO
INSERT INTO [layer] ([layerName], [intLayerTypeID], [sectionTypeID], [layerLevel]) VALUES ('standard', 3, '1002', 3);
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
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (1, 'feasibility', 1, NULL);
GO
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (2, 'consept design', 2, NULL);
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
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (8, 'new station 4', 1, NULL);
GO
INSERT INTO [station] ([stationID], [stationName], [layerID], [requiredDocID]) VALUES (9, 'new station 5', 2, NULL);
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
