import { useEffect, useState } from "react";
import type { EnvConfig } from "./shared";
import React from "react";

//const env = process.env.REACT_APP_ENV ?? process.env.NODE_ENV ?? "development";
const env = import.meta.env.MODE;

export type Environment = "production" | "staging" | "int" | "development";

export interface AppConfig extends EnvConfig {
    environment: Environment;
    isDev: boolean;
    isInt: boolean;
    isStaging: boolean;
    isProduction: boolean;
    cdnImg: string;
    cdnExcelTemplates: string;
    cdn: string;
}

// const envConfig = import(`./config.${env}`).config as EnvConfig;

// export const config: AppConfig = {
//     environment: env as Environment,
//     isDev: env === "development",
//     isInt: env === "int",
//     isStaging: env === "staging",
//     isProduction: env === "production",
//     ...envConfig,
//     cdnImg: "https://cdn.modilist.com/img",
//     cdnExcelTemplates: "https://cdn.modilist.com/excel-templates",
//     cdn: "https://cdn.modilist.com"
// };

export function useConfig(): AppConfig {
    const [config, setConfig] = useState({
        environment: env as Environment,
        isDev: env === "development",
        isInt: env === "int",
        isStaging: env === "staging",
        isProduction: env === "production",
        cdnImg: "https://cdn.modilist.com/img",
        cdnExcelTemplates: "https://cdn.modilist.com/excel-templates",
        cdn: "https://cdn.modilist.com"
    });

    const envFile = import(`./config.${env}.ts`);

    useEffect(() => {
        envFile.then(envConfig => {
            setConfig({
                ...config,
                ...envConfig.config
            })
        });
    }, [envFile]);
    
    return config;
}