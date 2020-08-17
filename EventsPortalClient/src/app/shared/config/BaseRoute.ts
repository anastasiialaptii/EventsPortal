import { Configuration } from './configuration';

export class BaseRoute {
    static Events: string = Configuration.URI + '/Event';
    static Visit: string = Configuration.URI + '/Visit';
    static Upload: string = Configuration.URI + '/Upload';
    static Auth: string = Configuration.URI + '/Auth';
    static User: string = Configuration.URI + '/User';
}