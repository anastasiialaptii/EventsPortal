export class Configuration {
    static URI: string = 'http://localhost:50618/api';
    static GoogleProvider: string = '1056893109317-gm4i7slkdmgb5r8breicrvfodok1o4lh.apps.googleusercontent.com';

    eventTypes = [
        { Id: 1, Name: "Private" },
        { Id: 2, Name: "Public" }
      ];

    minDate = new Date(Date.now());
}
