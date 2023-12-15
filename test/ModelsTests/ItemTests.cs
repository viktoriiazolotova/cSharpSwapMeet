using System;
using System.Collections.Generic;
using Xunit;
using cSharpSwapMeet;

namespace cSharpSwapMeetTests
{
    public class ItemTests
    {
        [Fact]
        public void GetConditionDescription_ShouldReturnCorrectString()
        {
            var table = new Decor();
            var phone = new Electronics(condition: 1);
            var sweather = new Clothing(condition: 2);
            var boots = new Clothing(condition: 2.5);
            var wallPicture = new Decor(condition: 3.5);
            var wallPicture2 = new Decor(condition: 4);
            var plant = new Decor(condition: 5.5);

            //default condition should be 0
            Assert.Equal(0, table.Condition);
            //to set condition
            table.Condition = 0.5;

            Assert.Equal("Heavily used", table.GetConditionDescription());
            Assert.Equal("Heavily used", phone.GetConditionDescription());
            Assert.Equal("Fair condition", sweather.GetConditionDescription());
            Assert.Equal("Good condition", boots.GetConditionDescription());
            Assert.Equal("Normal condition", wallPicture.GetConditionDescription());
            Assert.Equal("Normal condition", wallPicture2.GetConditionDescription());
            Assert.Equal("Excellent condition", plant.GetConditionDescription());
        }
    }
}
