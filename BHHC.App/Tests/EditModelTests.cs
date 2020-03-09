using AutoBogus;
using BHHC.Core;
using BHHC.ServiceLayer;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;


namespace BHHC.App
{

    public class EditModelTests
    {

        private readonly EditModel _target;
        private readonly IReasonService reasonServiceFake;

        public EditModelTests()
        {
            reasonServiceFake = A.Fake<IReasonService>();
            _target = new EditModel(reasonServiceFake);
            _target.Reason = AutoFaker.Generate<Reason>();
        }

        [Fact]
        public void OnPostAsync_UpdateFails_ReturnNotFound()
        {
            // Arrange
            A.CallTo(() => reasonServiceFake.UpdateReasonAsync(A<int>.Ignored, A<Reason>.Ignored)).Returns(0);

            // Act
            var actual = _target.OnPostAsync().GetAwaiter().GetResult();

            // Assert
            var result = actual as NotFoundResult;
            Assert.NotNull(result);
        }


        [Fact]
        public void OnPostAsync_UpdateSuccess_ReturnRedirect()
        {
            // Arrange
            A.CallTo(() => reasonServiceFake.UpdateReasonAsync(A<int>.Ignored, A<Reason>.Ignored)).Returns(1);

            // Act
            var actual = _target.OnPostAsync().GetAwaiter().GetResult();

            // Assert
            var result = actual as RedirectToPageResult;
            Assert.NotNull(result);
        }

    }
}
