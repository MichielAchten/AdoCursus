﻿CREATE PROCEDURE PostCodes
AS
	SELECT PostCode
	FROM Brouwers
	GROUP BY PostCode
	ORDER BY PostCode