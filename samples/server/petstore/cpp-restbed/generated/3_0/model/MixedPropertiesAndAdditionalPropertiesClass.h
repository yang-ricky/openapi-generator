/**
 * OpenAPI Petstore
 * This spec is mainly for testing Petstore server and contains fake endpoints, models. Please do not use this for any other purpose. Special characters: \" \\
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by OpenAPI-Generator 6.2.1-SNAPSHOT.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

/*
 * MixedPropertiesAndAdditionalPropertiesClass.h
 *
 * 
 */

#ifndef MixedPropertiesAndAdditionalPropertiesClass_H_
#define MixedPropertiesAndAdditionalPropertiesClass_H_



#include <string>
#include <map>
#include "Animal.h"
#include <memory>
#include <vector>
#include <boost/property_tree/ptree.hpp>
#include "helpers.h"

namespace org {
namespace openapitools {
namespace server {
namespace model {

/// <summary>
/// 
/// </summary>
class  MixedPropertiesAndAdditionalPropertiesClass 
{
public:
    MixedPropertiesAndAdditionalPropertiesClass() = default;
    explicit MixedPropertiesAndAdditionalPropertiesClass(boost::property_tree::ptree const& pt);
    virtual ~MixedPropertiesAndAdditionalPropertiesClass() = default;

    MixedPropertiesAndAdditionalPropertiesClass(const MixedPropertiesAndAdditionalPropertiesClass& other) = default; // copy constructor
    MixedPropertiesAndAdditionalPropertiesClass(MixedPropertiesAndAdditionalPropertiesClass&& other) noexcept = default; // move constructor

    MixedPropertiesAndAdditionalPropertiesClass& operator=(const MixedPropertiesAndAdditionalPropertiesClass& other) = default; // copy assignment
    MixedPropertiesAndAdditionalPropertiesClass& operator=(MixedPropertiesAndAdditionalPropertiesClass&& other) noexcept = default; // move assignment

    std::string toJsonString(bool prettyJson = false) const;
    void fromJsonString(std::string const& jsonString);
    boost::property_tree::ptree toPropertyTree() const;
    void fromPropertyTree(boost::property_tree::ptree const& pt);


    /////////////////////////////////////////////
    /// MixedPropertiesAndAdditionalPropertiesClass members

    /// <summary>
    /// 
    /// </summary>
    std::string getUuid() const;
    void setUuid(std::string value);

    /// <summary>
    /// 
    /// </summary>
    std::string getDateTime() const;
    void setDateTime(std::string value);

    /// <summary>
    /// 
    /// </summary>
    std::map<std::string, Animal> getMap() const;
    void setMap(std::map<std::string, Animal> value);

protected:
    std::string m_Uuid = "";
    std::string m_DateTime = "";
    std::map<std::string, Animal> m_map;
};

std::vector<MixedPropertiesAndAdditionalPropertiesClass> createMixedPropertiesAndAdditionalPropertiesClassVectorFromJsonString(const std::string& json);

template<>
inline boost::property_tree::ptree toPt<MixedPropertiesAndAdditionalPropertiesClass>(const MixedPropertiesAndAdditionalPropertiesClass& val) {
    return val.toPropertyTree();
}

template<>
inline MixedPropertiesAndAdditionalPropertiesClass fromPt<MixedPropertiesAndAdditionalPropertiesClass>(const boost::property_tree::ptree& pt) {
    MixedPropertiesAndAdditionalPropertiesClass ret;
    ret.fromPropertyTree(pt);
    return ret;
}

}
}
}
}

#endif /* MixedPropertiesAndAdditionalPropertiesClass_H_ */
