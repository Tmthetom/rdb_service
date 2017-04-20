CREATE PROCEDURE [sp_connectScenario]
  @selectedLanguage nvarchar(5)
  AS
  SELECT s.scenario_code, s.name, s.description, sa.type, sa.value, sa.language
  FROM scenario s
  LEFT JOIN scenario_contains sc ON s.scenario_code = sc.scenario_code
  LEFT JOIN scenario_attributes sa ON sc.attribute_code = sa.attribute_code AND (sa.language = @selectedLanguage OR sa.language IS NULL)
  RETURN
GO

CREATE PROCEDURE [sp_connectSection]
  @selectedLanguage nvarchar(5)
  AS
  SELECT s.section_code, s.name, s.description, sa.type, sa.value, sa.language
  FROM section s
  LEFT JOIN section_contains sc ON s.section_code = sc.section_code
  LEFT JOIN section_attributes sa ON sc.attribute_code = sa.attribute_code AND (sa.language = @selectedLanguage OR sa.language IS NULL)
  RETURN
GO

CREATE PROCEDURE [sp_connectCheck]
  @selectedLanguage nvarchar(5)
  AS
  SELECT cp.check_code, cp.name, cp.description, ca.type, ca.value, ca.language
  FROM check_point cp
  LEFT JOIN check_contains cc ON cp.check_code = cc.check_code
  LEFT JOIN check_attributes ca ON cc.attribute_code = ca.attribute_code AND (ca.language = @selectedLanguage OR ca.language IS NULL)
  RETURN
GO

CREATE PROCEDURE [sp_connectOperation]
  @selectedLanguage nvarchar(5)
  AS
  SELECT o.operation_code, o.name, o.description, oa.type, oa.value, oa.language
  FROM operation o
  LEFT JOIN operation_contains oc ON o.operation_code = oc.operation_code
  LEFT JOIN operation_attributes oa ON oc.attribute_code = oa.attribute_code AND (oa.language = @selectedLanguage OR oa.language IS NULL)
  RETURN
GO

