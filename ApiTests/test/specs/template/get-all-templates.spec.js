var assert = require('assert');
let chai = require("chai")
let chaiHttp = require("chai-http")
chai.use(chaiHttp);

var templateApi = require('../../fixtures/template.api');

describe('GET /api/templates - get all templates', function(){

    beforeEach(function(){
        console.log('beforeEach');
    });

    it('should return an empty array when there are no templates', function() {
        // return chai.request('https://localhost:44342/api')
        // .get('/templates')
        // .then(function (response) {
        //     // The response should be an empty array
        //     response.should.be.successful(200);
        //     response.body.should.be.an('array');
        // });
        return chai
            .request('https://localhost:44342/api')
            .get("/templates")
            .end((err, res) => {
                expect(res).to.have.status(200);
                done();
            });
    });
});