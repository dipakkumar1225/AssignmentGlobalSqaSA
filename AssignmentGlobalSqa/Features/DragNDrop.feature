Feature: DragNDrop
	Here included scenario are releated to drop-down interation 

Scenario: Check Drag and Drop the image(s) from gallery to trash or bin
	Given Access Drag And Drop from menu
	When Photo Manager tab, Drag and Drop the image(s) from gallery to trash or bin
	Then No image should be present under gallery