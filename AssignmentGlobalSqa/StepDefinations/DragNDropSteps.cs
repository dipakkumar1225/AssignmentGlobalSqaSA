using AssignmentGlobalSqa.PageObject;
using System;
using TechTalk.SpecFlow;

namespace AssignmentGlobalSqa.StepDefinations
{
    [Binding]
    public class DragNDropSteps
    {
        PageDragNDrop pageDragNDrop;

        public DragNDropSteps()
        {
            pageDragNDrop = new PageDragNDrop();
        }

        [Given(@"Access Drag And Drop from menu")]
        public void GivenOpenDragAndDropUrl()
        {
            pageDragNDrop.clickOnMenuDragNDrop();
        }

        [When(@"Photo Manager tab, Drag and Drop the image\(s\) from gallery to trash or bin")]
        public void WhenPhotoManagerTabDragAndDropTheImageSFromGalleryToTrashOrBin()
        {
            pageDragNDrop.dragNDropImagesFromGalleryToTrash();

        }

        [Then(@"No image should be present under gallery")]
        public void ThenNoImageShouldBePresentUnderGallery()
        {
            Console.WriteLine("ddddddddddddd");

        }
    }
}
