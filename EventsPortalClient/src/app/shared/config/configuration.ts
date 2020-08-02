export class Configuration {
    static URI: string = 'http://localhost:50618/api';
    static GoogleProvider: string = '1056893109317-gm4i7slkdmgb5r8breicrvfodok1o4lh.apps.googleusercontent.com';
    static token = JSON.parse(localStorage.getItem('socialusers'));

    public createImgPath = (serverPath: string) => {
        return `http://localhost:50618/${serverPath}`;
    }
}
