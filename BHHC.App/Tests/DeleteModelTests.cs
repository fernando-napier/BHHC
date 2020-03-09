using AutoBogus;
using BHHC.Core;
using BHHC.ServiceLayer;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BHHC.App
{
    public class DeleteModelTests
    {
        private readonly DeleteModel _target;
        private readonly IReasonService reasonServiceFake;

        public DeleteModelTests()
        {
            reasonServiceFake = A.Fake<IReasonService>();
            _target = new DeleteModel(reasonServiceFake);
            _target.Reason = AutoFaker.Generate<Reason>();
        }

        [Fact]
        public void OnPostAsync_NullId_ReturnsNotFound()
        {
            // Arrange

            // Act
            var actual = _target.OnPostAsync(null).GetAwaiter().GetResult();

            // Assert
            var result = actual as NotFoundResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void OnPostAsync_ReasonNull_DoesnotInvokeDeletionAndReturnsRedirect()
        {
            // Arrange
            A.CallTo(() => reasonServiceFake.GetReasonByIdAsync(A<int>.Ignored)).Returns(Task.FromResult<Reason>(null));

            // Act
            
            // get awaiter - get result so that we don't have to await this call, also safer than calling .Result
            var actual = _target.OnPostAsync(1).GetAwaiter().GetResult();

            // Assert

            // here we're making sure that no call to delete was made if the reason does not exist.
            A.CallTo(() => reasonServiceFake.DeleteReasonAsync(A<Reason>.Ignored)).MustNotHaveHappened();

            // this cast is so that we can be sure that the action result being returned is correct
            var result = actual as RedirectToPageResult;
            Assert.NotNull(result);
        }

        [Fact]
        public void OnPostAsync_ReasonNull_DeletesReasonAndReturnsRedirect()
        {
            // Arrange
            A.CallTo(() => reasonServiceFake.GetReasonByIdAsync(A<int>.Ignored)).Returns(_target.Reason);
            A.CallTo(() => reasonServiceFake.DeleteReasonAsync(A<Reason>.Ignored)).Returns(1);

            // Act

            // get awaiter - get result so that we don't have to await this call, also safer than calling .Result
            var actual = _target.OnPostAsync(1).GetAwaiter().GetResult();

            // Assert

            // here we're making sure that the deletion took place
            A.CallTo(() => reasonServiceFake.DeleteReasonAsync(A<Reason>.Ignored)).MustHaveHappenedOnceExactly();
            // this cast is so that we can be sure that the action result being returned is correct
            var result = actual as RedirectToPageResult;
            Assert.NotNull(result);
        }
    }
}
