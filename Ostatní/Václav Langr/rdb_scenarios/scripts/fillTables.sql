Insert into operation(operation_code, name, description) values('op_0000001', 'Operation_1', 'Description_1')
go
Insert into operation(operation_code, name, description) values('op_0000002', 'Operation_2', 'Description_2')
go
Insert into operation(operation_code, name, description) values('op_0000003', 'Operation_3', 'Description_3')
go
Insert into operation(operation_code, name, description) values('op_0000004', 'Operation_4', 'Description_4')
go                                    
Insert into operation(operation_code, name, description) values('op_0000005', 'Operation_5', 'Description_5')
go
Insert into operation(operation_code, name, description) values('op_0000006', 'Operation_6', 'Description_6')
go

Insert into operation_attributes(attribute_code, type, language, value) values('at_0000001', 'name', 'en_US', 'Operation_1_enUS')
go
Insert into operation_attributes(attribute_code, type, language, value) values('at_0000002', 'desc', 'en_US', 'Description_1_enUS')
go
Insert into operation_attributes(attribute_code, type, value) values('at_0000003', 'image', 'url')
go
Insert into operation_attributes(attribute_code, type, language, value) values('at_0000004', 'name', 'cs_CZ', 'Operation_3_csCZ')
go

Insert into operation_contains(attribute_code, operation_code) values('at_0000001', 'op_0000001')
go
Insert into operation_contains(attribute_code, operation_code) values('at_0000002', 'op_0000001')
go
Insert into operation_contains(attribute_code, operation_code) values('at_0000003', 'op_0000002')
go
Insert into operation_contains(attribute_code, operation_code) values('at_0000004', 'op_0000003')
go



Insert into check_point(check_code, name, description) values('cp_0000001', 'Check_point_1', 'Description_1')
go
Insert into check_point(check_code, name, description) values('cp_0000002', 'Check_point_2', 'Description_2')
go
Insert into check_point(check_code, name, description) values('cp_0000003', 'Check_point_3', 'Description_3')
go
Insert into check_point(check_code, name, description) values('cp_0000004', 'Check_point_4', 'Description_4')
go
Insert into check_point(check_code, name, description) values('cp_0000005', 'Check_point_5', 'Description_5')
go
Insert into check_point(check_code, name, description) values('cp_0000006', 'Check_point_6', 'Description_6')
go

Insert into check_attributes(attribute_code, type, language, value) values('at_0000001', 'name', 'en_US', 'Check_point_1_enUS')
go
Insert into check_attributes(attribute_code, type, language, value) values('at_0000002', 'desc', 'en_GB', 'Description_2_enGB')
go
Insert into check_attributes(attribute_code, type, value) values('at_0000003', 'packet', 'Kd01')
go
Insert into check_attributes(attribute_code, type, language, value) values('at_0000004', 'name', 'cs_CZ', 'Check_point_4_csCZ')
go

Insert into check_contains(attribute_code, check_code) values('at_0000001', 'cp_0000001')
go
Insert into check_contains(attribute_code, check_code) values('at_0000002', 'cp_0000002')
go
Insert into check_contains(attribute_code, check_code) values('at_0000003', 'cp_0000005')
go
Insert into check_contains(attribute_code, check_code) values('at_0000004', 'cp_0000004')
go



Insert into section(section_code, name, description) values('se_0000001', 'Section_1', 'Description_1')
go
Insert into section(section_code, name, description) values('se_0000002', 'Section_2', 'Description_2')
go
Insert into section(section_code, name, description) values('se_0000003', 'Section_3', 'Description_3')
go
Insert into section(section_code, name, description) values('se_0000004', 'Section_4', 'Description_4')
go
Insert into section(section_code, name, description) values('se_0000005', 'Section_5', 'Description_5')
go
Insert into section(section_code, name, description) values('se_0000006', 'Section_6', 'Description_6')
go

Insert into section_attributes(attribute_code, type, language, value) values('at_0000001', 'name', 'en_US', 'Section_1_enUS')
go
Insert into section_attributes(attribute_code, type, language, value) values('at_0000002', 'desc', 'en_GB', 'Description_2_enGB')
go
Insert into section_attributes(attribute_code, type, value) values('at_0000003', 'info', 'More descriptive info')
go
Insert into section_attributes(attribute_code, type, language, value) values('at_0000004', 'name', 'cs_CZ', 'Section_4_csCZ')
go

Insert into section_contains(attribute_code, section_code) values('at_0000001', 'se_0000001')
go
Insert into section_contains(attribute_code, section_code) values('at_0000002', 'se_0000002')
go
Insert into section_contains(attribute_code, section_code) values('at_0000003', 'se_0000005')
go
Insert into section_contains(attribute_code, section_code) values('at_0000004', 'se_0000004')
go



Insert into scenario(scenario_code, name, description) values('sc_0000001', 'Scenario_1', 'Description_1')
go
Insert into scenario(scenario_code, name, description) values('sc_0000002', 'Scenario_2', 'Description_2')
go
Insert into scenario(scenario_code, name, description) values('sc_0000003', 'Scenario_3', 'Description_3')
go
Insert into scenario(scenario_code, name, description) values('sc_0000004', 'Scenario_4', 'Description_4')
go
Insert into scenario(scenario_code, name, description) values('sc_0000005', 'Scenario_5', 'Description_5')
go
Insert into scenario(scenario_code, name, description) values('sc_0000006', 'Scenario_6', 'Description_6')
go

Insert into scenario_attributes(attribute_code, type, language, value) values('at_0000001', 'name', 'en_US', 'Scenario_1_enUS')
go
Insert into scenario_attributes(attribute_code, type, language, value) values('at_0000002', 'desc', 'en_GB', 'Description_2_enGB')
go
Insert into scenario_attributes(attribute_code, type, language, value) values('at_0000003', 'name', 'cs_CZ', 'Scenario_4_csCZ')
go

Insert into scenario_contains(attribute_code, scenario_code) values('at_0000001', 'sc_0000001')
go
Insert into scenario_contains(attribute_code, scenario_code) values('at_0000002', 'sc_0000002')
go
Insert into scenario_contains(attribute_code, scenario_code) values('at_0000003', 'sc_0000004')
go



Insert into scenario_checks(section_order, scenario_code, section_code, check_code, check_order) values(1, 'sc_0000001', 'se_0000001', 'cp_0000001', 1)
go
Insert into scenario_checks(section_order, scenario_code, section_code, check_code, check_order) values(1, 'sc_0000001', 'se_0000001', 'cp_0000003', 2)
go
Insert into scenario_checks(section_order, scenario_code, section_code, check_code, check_order) values(2, 'sc_0000001', 'se_0000003', 'cp_0000004', 1)
go
Insert into scenario_checks(section_order, scenario_code, section_code, check_code, check_order) values(3, 'sc_0000001', 'se_0000001', 'cp_0000001', 1)
go


Insert into check_operations(operation_code, check_code, [order]) values('op_0000001', 'cp_0000001', 1)
go
Insert into check_operations(operation_code, check_code, [order]) values('op_0000005', 'cp_0000001', 2)
go
Insert into check_operations(operation_code, check_code, [order]) values('op_0000006', 'cp_0000001', 3)
go
Insert into check_operations(operation_code, check_code, [order]) values('op_0000004', 'cp_0000003', 1)
go
Insert into check_operations(operation_code, check_code, [order]) values('op_0000005', 'cp_0000003', 2)
go
Insert into check_operations(operation_code, check_code, [order]) values('op_0000006', 'cp_0000004', 1)
go