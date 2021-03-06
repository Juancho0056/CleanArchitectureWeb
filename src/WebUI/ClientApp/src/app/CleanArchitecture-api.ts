﻿/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.3.0.0 (NJsonSchema v10.1.11.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface IBienJuridicoClient {
    create(command: CreateTodoBasicRequest): Observable<ProblemDetails>;
    update(command: UpdateTodoBasicRequest): Observable<ProblemDetails>;
    delete(command: DeleteTodoBasicRequest): Observable<ProblemDetails>;
    getAll(): Observable<TodoBasic[]>;
    get(key: number | undefined): Observable<SingleResultOfTodoBasic>;
}

@Injectable({
    providedIn: 'root'
})
export class BienJuridicoClient implements IBienJuridicoClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    create(command: CreateTodoBasicRequest): Observable<ProblemDetails> {
        let url_ = this.baseUrl + "/api/BienJuridico/Create";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",			
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCreate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCreate(<any>response_);
                } catch (e) {
                    return <Observable<ProblemDetails>><any>_observableThrow(e);
                }
            } else
                return <Observable<ProblemDetails>><any>_observableThrow(response_);
        }));
    }

    protected processCreate(response: HttpResponseBase): Observable<ProblemDetails> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 404) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            }));
        } else if (status === 401) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result401: any = null;
            let resultData401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result401 = ProblemDetails.fromJS(resultData401);
            return throwException("A server side error occurred.", status, _responseText, _headers, result401);
            }));
        } else {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let resultdefault: any = null;
            let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            resultdefault = ProblemDetails.fromJS(resultDatadefault);
            return _observableOf(resultdefault);
            }));
        }
    }

    update(command: UpdateTodoBasicRequest): Observable<ProblemDetails> {
        let url_ = this.baseUrl + "/api/BienJuridico/Update";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",			
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("patch", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processUpdate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processUpdate(<any>response_);
                } catch (e) {
                    return <Observable<ProblemDetails>><any>_observableThrow(e);
                }
            } else
                return <Observable<ProblemDetails>><any>_observableThrow(response_);
        }));
    }

    protected processUpdate(response: HttpResponseBase): Observable<ProblemDetails> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 404) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            }));
        } else if (status === 401) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result401: any = null;
            let resultData401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result401 = ProblemDetails.fromJS(resultData401);
            return throwException("A server side error occurred.", status, _responseText, _headers, result401);
            }));
        } else {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let resultdefault: any = null;
            let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            resultdefault = ProblemDetails.fromJS(resultDatadefault);
            return _observableOf(resultdefault);
            }));
        }
    }

    delete(command: DeleteTodoBasicRequest): Observable<ProblemDetails> {
        let url_ = this.baseUrl + "/api/BienJuridico/Delete";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",			
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDelete(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDelete(<any>response_);
                } catch (e) {
                    return <Observable<ProblemDetails>><any>_observableThrow(e);
                }
            } else
                return <Observable<ProblemDetails>><any>_observableThrow(response_);
        }));
    }

    protected processDelete(response: HttpResponseBase): Observable<ProblemDetails> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 404) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result404: any = null;
            let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result404 = ProblemDetails.fromJS(resultData404);
            return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            }));
        } else if (status === 401) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result401: any = null;
            let resultData401 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result401 = ProblemDetails.fromJS(resultData401);
            return throwException("A server side error occurred.", status, _responseText, _headers, result401);
            }));
        } else {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let resultdefault: any = null;
            let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            resultdefault = ProblemDetails.fromJS(resultDatadefault);
            return _observableOf(resultdefault);
            }));
        }
    }

    getAll(): Observable<TodoBasic[]> {
        let url_ = this.baseUrl + "/api/BienJuridico/GetAll";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",			
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetAll(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetAll(<any>response_);
                } catch (e) {
                    return <Observable<TodoBasic[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<TodoBasic[]>><any>_observableThrow(response_);
        }));
    }

    protected processGetAll(response: HttpResponseBase): Observable<TodoBasic[]> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(TodoBasic.fromJS(item));
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<TodoBasic[]>(<any>null);
    }

    get(key: number | undefined): Observable<SingleResultOfTodoBasic> {
        let url_ = this.baseUrl + "/api/BienJuridico/Get?";
        if (key === null)
            throw new Error("The parameter 'key' cannot be null.");
        else if (key !== undefined)
            url_ += "key=" + encodeURIComponent("" + key) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",			
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(<any>response_);
                } catch (e) {
                    return <Observable<SingleResultOfTodoBasic>><any>_observableThrow(e);
                }
            } else
                return <Observable<SingleResultOfTodoBasic>><any>_observableThrow(response_);
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<SingleResultOfTodoBasic> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = SingleResultOfTodoBasic.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<SingleResultOfTodoBasic>(<any>null);
    }
}

export class ProblemDetails implements IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
    extensions?: { [key: string]: any; } | undefined;

    constructor(data?: IProblemDetails) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.type = _data["type"];
            this.title = _data["title"];
            this.status = _data["status"];
            this.detail = _data["detail"];
            this.instance = _data["instance"];
            if (_data["extensions"]) {
                this.extensions = {} as any;
                for (let key in _data["extensions"]) {
                    if (_data["extensions"].hasOwnProperty(key))
                        this.extensions![key] = _data["extensions"][key];
                }
            }
        }
    }

    static fromJS(data: any): ProblemDetails {
        data = typeof data === 'object' ? data : {};
        let result = new ProblemDetails();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["title"] = this.title;
        data["status"] = this.status;
        data["detail"] = this.detail;
        data["instance"] = this.instance;
        if (this.extensions) {
            data["extensions"] = {};
            for (let key in this.extensions) {
                if (this.extensions.hasOwnProperty(key))
                    data["extensions"][key] = this.extensions[key];
            }
        }
        return data; 
    }
}

export interface IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
    extensions?: { [key: string]: any; } | undefined;
}

export abstract class CommandRequestOfICollectionOfTodoBasicDto implements ICommandRequestOfICollectionOfTodoBasicDto {

    constructor(data?: ICommandRequestOfICollectionOfTodoBasicDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
    }

    static fromJS(data: any): CommandRequestOfICollectionOfTodoBasicDto {
        data = typeof data === 'object' ? data : {};
        throw new Error("The abstract class 'CommandRequestOfICollectionOfTodoBasicDto' cannot be instantiated.");
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        return data; 
    }
}

export interface ICommandRequestOfICollectionOfTodoBasicDto {
}

export class CreateTodoBasicRequest extends CommandRequestOfICollectionOfTodoBasicDto implements ICreateTodoBasicRequest {
    title?: string | undefined;

    constructor(data?: ICreateTodoBasicRequest) {
        super(data);
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.title = _data["title"];
        }
    }

    static fromJS(data: any): CreateTodoBasicRequest {
        data = typeof data === 'object' ? data : {};
        let result = new CreateTodoBasicRequest();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["title"] = this.title;
        super.toJSON(data);
        return data; 
    }
}

export interface ICreateTodoBasicRequest extends ICommandRequestOfICollectionOfTodoBasicDto {
    title?: string | undefined;
}

export class UpdateTodoBasicRequest extends CommandRequestOfICollectionOfTodoBasicDto implements IUpdateTodoBasicRequest {
    id?: number;
    title?: string | undefined;

    constructor(data?: IUpdateTodoBasicRequest) {
        super(data);
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.id = _data["id"];
            this.title = _data["title"];
        }
    }

    static fromJS(data: any): UpdateTodoBasicRequest {
        data = typeof data === 'object' ? data : {};
        let result = new UpdateTodoBasicRequest();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["title"] = this.title;
        super.toJSON(data);
        return data; 
    }
}

export interface IUpdateTodoBasicRequest extends ICommandRequestOfICollectionOfTodoBasicDto {
    id?: number;
    title?: string | undefined;
}

export class DeleteTodoBasicRequest extends CommandRequestOfICollectionOfTodoBasicDto implements IDeleteTodoBasicRequest {
    id?: number;

    constructor(data?: IDeleteTodoBasicRequest) {
        super(data);
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.id = _data["id"];
        }
    }

    static fromJS(data: any): DeleteTodoBasicRequest {
        data = typeof data === 'object' ? data : {};
        let result = new DeleteTodoBasicRequest();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        super.toJSON(data);
        return data; 
    }
}

export interface IDeleteTodoBasicRequest extends ICommandRequestOfICollectionOfTodoBasicDto {
    id?: number;
}

export abstract class AuditableEntity implements IAuditableEntity {
    createdBy?: string | undefined;
    created?: Date;
    lastModifiedBy?: string | undefined;
    lastModified?: Date | undefined;

    constructor(data?: IAuditableEntity) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.createdBy = _data["createdBy"];
            this.created = _data["created"] ? new Date(_data["created"].toString()) : <any>undefined;
            this.lastModifiedBy = _data["lastModifiedBy"];
            this.lastModified = _data["lastModified"] ? new Date(_data["lastModified"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): AuditableEntity {
        data = typeof data === 'object' ? data : {};
        throw new Error("The abstract class 'AuditableEntity' cannot be instantiated.");
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["createdBy"] = this.createdBy;
        data["created"] = this.created ? this.created.toISOString() : <any>undefined;
        data["lastModifiedBy"] = this.lastModifiedBy;
        data["lastModified"] = this.lastModified ? this.lastModified.toISOString() : <any>undefined;
        return data; 
    }
}

export interface IAuditableEntity {
    createdBy?: string | undefined;
    created?: Date;
    lastModifiedBy?: string | undefined;
    lastModified?: Date | undefined;
}

export class TodoBasic extends AuditableEntity implements ITodoBasic {
    id?: number;
    listId?: number;
    title?: string | undefined;
    note?: string | undefined;
    done?: boolean;
    reminder?: Date | undefined;
    priority?: PriorityLevel;

    constructor(data?: ITodoBasic) {
        super(data);
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.id = _data["id"];
            this.listId = _data["listId"];
            this.title = _data["title"];
            this.note = _data["note"];
            this.done = _data["done"];
            this.reminder = _data["reminder"] ? new Date(_data["reminder"].toString()) : <any>undefined;
            this.priority = _data["priority"];
        }
    }

    static fromJS(data: any): TodoBasic {
        data = typeof data === 'object' ? data : {};
        let result = new TodoBasic();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["listId"] = this.listId;
        data["title"] = this.title;
        data["note"] = this.note;
        data["done"] = this.done;
        data["reminder"] = this.reminder ? this.reminder.toISOString() : <any>undefined;
        data["priority"] = this.priority;
        super.toJSON(data);
        return data; 
    }
}

export interface ITodoBasic extends IAuditableEntity {
    id?: number;
    listId?: number;
    title?: string | undefined;
    note?: string | undefined;
    done?: boolean;
    reminder?: Date | undefined;
    priority?: PriorityLevel;
}

export enum PriorityLevel {
    None = 0,
    Low = 1,
    Medium = 2,
    High = 3,
}

export abstract class SingleResult implements ISingleResult {
    queryable?: any[] | undefined;

    constructor(data?: ISingleResult) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["queryable"])) {
                this.queryable = [] as any;
                for (let item of _data["queryable"])
                    this.queryable!.push(item);
            }
        }
    }

    static fromJS(data: any): SingleResult {
        data = typeof data === 'object' ? data : {};
        throw new Error("The abstract class 'SingleResult' cannot be instantiated.");
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.queryable)) {
            data["queryable"] = [];
            for (let item of this.queryable)
                data["queryable"].push(item);
        }
        return data; 
    }
}

export interface ISingleResult {
    queryable?: any[] | undefined;
}

export class SingleResultOfTodoBasic extends SingleResult implements ISingleResultOfTodoBasic {
    queryable?: TodoBasic[] | undefined;

    constructor(data?: ISingleResultOfTodoBasic) {
        super(data);
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            if (Array.isArray(_data["queryable"])) {
                this.queryable = [] as any;
                for (let item of _data["queryable"])
                    this.queryable!.push(TodoBasic.fromJS(item));
            }
        }
    }

    static fromJS(data: any): SingleResultOfTodoBasic {
        data = typeof data === 'object' ? data : {};
        let result = new SingleResultOfTodoBasic();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.queryable)) {
            data["queryable"] = [];
            for (let item of this.queryable)
                data["queryable"].push(item.toJSON());
        }
        super.toJSON(data);
        return data; 
    }
}

export interface ISingleResultOfTodoBasic extends ISingleResult {
    queryable?: TodoBasic[] | undefined;
}

export class SwaggerException extends Error {
    message: string;
    status: number; 
    response: string; 
    headers: { [key: string]: any; };
    result: any; 

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader(); 
            reader.onload = event => { 
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob); 
        }
    });
}