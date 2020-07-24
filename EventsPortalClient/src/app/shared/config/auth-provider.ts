import { AuthServiceConfig, GoogleLoginProvider } from "angular-6-social-login";
import { Configuration } from './configuration'

export function getAuthServiceConfigs() {
    let config = new AuthServiceConfig(
        [
            {
                id: GoogleLoginProvider.PROVIDER_ID,
                provider: new GoogleLoginProvider(Configuration.GoogleProvider)
            }
        ]
    );
    return config;
}