const { Given, When, Then } = require("cucumber");

Given(/^I navigate to "([^"]*)"$/, {timeout: 2 * 5000},  async (url) => {
    browser.waitForAngularEnabled(false);

    await browser.get(url, 5000);
    debugger
  
    
    var searchField = await element(by.xpath('//*[@id="tsf"]/div[2]/div[1]/div[1]/div/div[2]/input'));
    searchField.clear().sendKeys('searchKeyword');

    debugger
    // expect(
    //     await element(by.xpath('//*[@id="hplogo"]')).isDisplayed()
    // ).to.eventually.to.equal(true);

});

Then(/^I should see the search page$/, {timeout: 2 * 5000}, async () => {
    const googleLogo = await element(by.id("hplogo2"))
    expect(googleLogo.isDisplayed()).to.eventually.to.equal(true);
});

When(/^I enter search keyword as "([^"]*)"$/, async (searchKeyword) => {
    var searchField = await element(by.xpath('//*[@id="tsf"]/div[2]/div[1]/div[1]/div/div[2]/input'));
    searchField.clear().sendKeys(searchKeyword);
}
);

When(/^I Click on search button$/, async () => {
    var loginButton = await element(by.xpath('//*[@id="tsf"]/div[2]/div[1]/div[3]/center/input[1]'));
    loginButton.click();
});

Then(/^I should see found results$/, async (searchKeyword) => {
    var resultStats = await element(by.xpath('//*[@id="result-stats"]'));

    expect(resultStats.isDisplayed()).to.eventually.to.equal(true);
});
