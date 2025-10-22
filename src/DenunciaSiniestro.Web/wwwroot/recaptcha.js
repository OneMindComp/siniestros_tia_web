window.recaptchaService = {
    execute: function (siteKey, action) {
        return new Promise(function (resolve, reject) {
            grecaptcha.ready(function () {
                grecaptcha.execute(siteKey, { action: action })
                    .then(function (token) {
                        resolve(token);
                    })
                    .catch(function (err) {
                        reject(err);
                    });
            });
        });
    }
};
